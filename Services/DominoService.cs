using DominoApi.Exceptions;
using DominoApi.Model;

namespace DominoApi.Services
{
    public class DominoService
    {

        public List<Domino> ObteinListChain(List<Domino> dominoes)
        {
            if (dominoes.Count < 2 || dominoes.Count > 6)
            {
                throw new NotValidChainException();
            }

            var combinations = new List<List<Domino>>();
            GetCombinations(dominoes, new List<Domino>(), combinations);

            foreach (var combination in combinations)
            {
                if (IsAdjacentChain(combination)) return combination;
            }

            throw new NotValidChainException();
        }

        public void GetCombinations(List<Domino> dominoes, List<Domino> currentCombination, List<List<Domino>> combinations)
        {

            if (dominoes.Count == 0)
            {
                combinations.Add(currentCombination);
                return;
            }

            foreach (var domino in dominoes)
            {
                var newDominos = new List<Domino>(dominoes);
                newDominos.Remove(domino);

                var newCombination = new List<Domino>(currentCombination);
                newCombination.Add(domino);

                if (currentCombination.Count == 0 ||
                    currentCombination.Last().LastNumber == domino.FirstNumber)
                {
                    GetCombinations(newDominos, newCombination, combinations);
                }

                if (currentCombination.Count == 0 ||
                    currentCombination.Last().LastNumber == domino.LastNumber)
                {
                    var aux = domino.FirstNumber;
                    domino.FirstNumber = domino.LastNumber;
                    domino.LastNumber = aux;
                    GetCombinations(newDominos, newCombination, combinations);
                }
            }
        }

        public bool IsAdjacentChain(List<Domino> combination)
        {
            var firstDomino = combination[0];
            var lastDomino = combination[combination.Count - 1];

            if (firstDomino.FirstNumber != lastDomino.LastNumber)
            {
                return false;
            }

            for (int i = 0; i < combination.Count - 1; i++)
            {
                var currentDomino = combination[i];
                var nextDomino = combination[i + 1];
                if (currentDomino.LastNumber != nextDomino.FirstNumber)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
