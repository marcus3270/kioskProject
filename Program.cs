namespace kioskProject {
    internal class Program {
        //instance of class
        static CashBox _cashBox= new CashBox(100, 200,100, 100, 200, 300, 300, 300, 300);
        
        static void Main(string[] args) {
            _cashBox.ItemAdder();
            //Console.WriteLine(_cashBox.GetHundredNumber());
            // CashBox dispenser = new CashBox(2, 100, 100, 100, 100, 200, 200, 200, 300);
            // double money = _cashBox.ItemAdder();
            // _cashBox.creditAccepter(money);
            // _cashBox.moneyTaker(money);

            //string[] result;
            //result = CashBox.MoneyRequest("44444444444444444", 535.22);
            //CashBox DispenseCash(200);
            // Example: Dispense $370.75
            //dispenser.DispenseCash(375.71);
            //Console.WriteLine(_cashBox.GetHundredNumber()); 

        }//end main
        #region Helper Functions
        static string Input(string message) {
            Console.Write(message);
            return Console.ReadLine();
        }//function end

        static decimal InputDecimal(string message) {
            string value = Input(message);
            return decimal.Parse(value);
        }//function end

        static double InputDouble(string message) {
            string value = Input(message);
            return double.Parse(value);
        }//function end

        static int InputInt(string message) {
            string value = Input(message);
            return int.Parse(value);
        }//function end

        static int TryInputInt(string message) {
            //variables
            int parsedValue = 0;
            bool gotParsed = false;
            //validation loop until valid int is submitted
            do {
                gotParsed = int.TryParse(Input(message), out parsedValue);
            } while (gotParsed == false);
            //return parsed value
            return parsedValue;
        }//function end

        static double TryInputDouble(string message) {
            //variables
            double parsedValue = 0;
            bool gotParsed = false;
            //validation loop until valid int is submitted
            do {
                gotParsed = double.TryParse(Input(message), out parsedValue);
            } while (gotParsed == false);
            //return parsed value
            return parsedValue;
        }//function end

        static decimal TryInputDecimal(string message) {
            //variables
            decimal parsedValue = 0;
            bool gotParsed = false;
            //validation loop until valid int is submitted
            do {
                gotParsed = decimal.TryParse(Input(message), out parsedValue);
            } while (gotParsed == false);
            //return parsed value
            return parsedValue;
        }//function end
        #endregion
    }
}