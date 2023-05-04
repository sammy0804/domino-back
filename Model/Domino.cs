namespace DominoApi.Model
{
    public class Domino
    {
        public int FirstNumber { get; set; }
        public int LastNumber { get; set; }

        public void Token(int firstNumber, int lastNumber)
        {
            FirstNumber = firstNumber;
            LastNumber = lastNumber;
        }

        public override string ToString()
        {
            return $"[{FirstNumber}|{LastNumber}]";
        }

    }
}
