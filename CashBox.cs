using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Linq;

internal class CashBox {
    private decimal _hundredDollarBills;
    private decimal _twentyDollarBills;
    private decimal _tenDollarBills;
    private decimal _fiveDollarBills;
    private decimal _oneDollarBills;
    private decimal _quarterCoins;
    private decimal _dimeCoins;
    private decimal _nickelCoins;
    private decimal _pennyCoins;

    //constuctor
    public CashBox(decimal hundreds, decimal twenties, decimal tens, decimal fives, decimal ones, decimal quarters, decimal dimes, decimal nickels, decimal pennies) {
        //fields
        _hundredDollarBills = hundreds;
        _twentyDollarBills = twenties;
        _tenDollarBills = tens;
        _fiveDollarBills = fives;
        _oneDollarBills = ones;
        _quarterCoins = quarters;
        _dimeCoins = dimes;
        _nickelCoins = nickels;
        _pennyCoins = pennies;
    }
    // dispense cash
    public void DispenseCash(decimal amount) {
        //decimal returnMoney = amount;
        decimal remainingAmount = amount;

        // Calculate the number of each denomination to dispense
        decimal hundredCount = Math.Floor( Math.Min(remainingAmount / 100, _hundredDollarBills));
        remainingAmount -= hundredCount * 100;        
        remainingAmount=Math.Round(remainingAmount, 2);

        decimal twentyCount = Math.Floor(Math.Min(remainingAmount / 20, _twentyDollarBills));
        remainingAmount -= twentyCount * 20;
        remainingAmount = Math.Round(remainingAmount, 2);

        decimal tenCount = Math.Floor(Math.Min(remainingAmount / 10, _tenDollarBills));
        remainingAmount -= tenCount * 10;
        remainingAmount = Math.Round(remainingAmount, 2);

        decimal fiveCount = Math.Floor(Math.Min(remainingAmount / 5, _fiveDollarBills));
        remainingAmount -= fiveCount * 5;
        remainingAmount = Math.Round(remainingAmount, 2);

        decimal oneCount = Math.Floor(Math.Min(remainingAmount / 1, _oneDollarBills));
        remainingAmount -= oneCount * 1;
        remainingAmount = Math.Round(remainingAmount, 2);

        decimal quarterCount = Math.Floor(Math.Min(remainingAmount / 0.25M, _quarterCoins));
        remainingAmount -= (quarterCount * 0.25M);
        remainingAmount = Math.Round(remainingAmount, 2);

        decimal dimeCount = Math.Floor(Math.Min(remainingAmount / 0.1M, _dimeCoins));
        remainingAmount -= (dimeCount * 0.1M);
        remainingAmount = Math.Round(remainingAmount, 2);

        decimal nickelCount = Math.Floor(Math.Min(remainingAmount / 0.05M, _nickelCoins));
        remainingAmount -= (nickelCount * 0.05M);
        remainingAmount = Math.Round(remainingAmount, 2);

        decimal pennyCount = Math.Min(remainingAmount / 0.01M, _pennyCoins);
        remainingAmount -= (pennyCount * 0.01M);

        // Check if there is enough cash to dispense
        if (remainingAmount > 0) {
            Console.WriteLine("Insufficient funds in the dispenser. Enter a different form of payment");
         
        } else {
            // Update the dispenser quantities
            _hundredDollarBills -= hundredCount;
            _twentyDollarBills -= twentyCount;
            _tenDollarBills -= tenCount;
            _fiveDollarBills -= fiveCount;
            _oneDollarBills -= oneCount;
            _quarterCoins -= quarterCount;
            _dimeCoins -= dimeCount;
            _nickelCoins -= nickelCount;
            _pennyCoins -= pennyCount;

            // Display the dispensed cash
            
            while (hundredCount > 0) {
                Console.WriteLine("100.00 dispensed");
                hundredCount--;
            }
            while (twentyCount > 0) {
                Console.WriteLine("20.00 dispensed");
                twentyCount--;
            }
            while (tenCount > 0) {
                Console.WriteLine("10.00 dispensed");
                tenCount--;
            }
            while (fiveCount > 0) {
                Console.WriteLine("5.00 dispensed");
                fiveCount--;
            }
            while (oneCount > 0) {
                Console.WriteLine("1.00 dispensed");
                oneCount--;
            }
            while (quarterCount > 0) {
                Console.WriteLine(".25 dispensed");
                quarterCount--;
            }
            while (dimeCount > 0) {
                Console.WriteLine(".10 dispensed");
                dimeCount--;
            } while (nickelCount > 0) {
                Console.WriteLine(".05 dispensed");
                nickelCount--;
            }
            while (pennyCount > 0) {
                Console.WriteLine(".01 dispensed");
                pennyCount--;
            }
        }       
    }

    /*public void MoneyReturn(double returnMoney) {
        DispenseCash((decimal)returnMoney);
        creditAccepter((double)returnMoney);
    }*/
    public void SetHundredNumber(decimal value) {
        _hundredDollarBills = value;
    }//end method
    public decimal GetHundredNumber() {
        return _hundredDollarBills;
    }//end method

    //ADD ITEMS
    public void ItemAdder() {

        
        List<decimal> enteredItems = new List<decimal>();
        //VARIABLES
        decimal number;
        bool isTrue = true;
        decimal total = 0;
        
        do {
            //List<double> enteredItems = new List<double>();

            Console.Write("Enter a item price and press enter (or leave blank and press Enter to end): ");
            
            string items = Console.ReadLine();
            if (string.IsNullOrEmpty(items)) {
                isTrue = false; // Terminate the loop if the user presses Enter without entering a number
            } else if (decimal.TryParse(items, out number)) {

                // Process the valid number here
                //Console.WriteLine("You entered: {0}", number);
                Console.WriteLine(number);

                total = number + total;
                enteredItems.Add(number);
                // enteredItems = number;
            } else {
                Console.WriteLine("Invalid input. Please enter a number.");
                
            }

        }
        while (isTrue);
        //List<double> enteredItems = new List<double>();
        int counter = 1;
        Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        foreach (decimal item in enteredItems) {
            Console.WriteLine($"Item {counter}: {item}");
            counter++;
        }
        decimal roundedTotal = Math.Round(total, 2); // Output: 3.14      
        Console.WriteLine($"Total: {roundedTotal}");
        Console.WriteLine();
        //return roundedTotal;
        Chooser(roundedTotal);

    }
    //CHOOSE CASH OR CREDIT CARD PAYMENT
    public void Chooser(decimal roundedTotal) {
        
        bool isTrue = true;
        while (isTrue) {
            decimal choose = TryInputInt("press 1 for cash payment press 2 for credit card payment: ");
            if (choose == 1) {
                moneyTaker(roundedTotal);
                isTrue = false;
            } else if (choose == 2) {
                creditAccepter(roundedTotal);
                isTrue = false;
            }
        }       
    }//function end

    //PROCESS MONEY
    public void moneyTaker(decimal money) {
        decimal paymentTotal = 0;
        List<decimal> moneyReturn = new List<decimal>();
        while (paymentTotal < money) {
            decimal remaining = money - paymentTotal;
            decimal paymentCollector = 0;
            while(paymentCollector != 100 && paymentCollector != 20 && paymentCollector != 10 && paymentCollector != 5 && paymentCollector != 1 && paymentCollector != .25M && paymentCollector != .10M && paymentCollector != .05M && paymentCollector !=.01M) {
                paymentCollector = TryInputDecimal("Insert Cash: ");
            }
                       
            if (paymentCollector == 100) {
                _hundredDollarBills += 1;
            }
            else if(paymentCollector == 20) {
                _twentyDollarBills += 1;
            } else if (paymentCollector == 10) {
                _tenDollarBills += 1;
            } else if (paymentCollector == 5) {
                _fiveDollarBills += 1;
            } else if (paymentCollector == 1) {
                _oneDollarBills += 1;
            } else if (paymentCollector == .25M) {
                _quarterCoins += 1;
            } else if (paymentCollector == .10M) {
                _dimeCoins += 1;
            } else if (paymentCollector == .05M) {
                _nickelCoins += 1;
            }
            // list
            moneyReturn.Add(paymentCollector);
            ////
            paymentTotal += paymentCollector;
            decimal subtotal = money - paymentTotal;
            decimal roundedSubTotal = Math.Round(subtotal, 2); // Output: 3.14      
            if(paymentTotal< money) {
                Console.WriteLine($"Remaining {roundedSubTotal}");
            } else {
                Console.WriteLine($"Change {Math.Abs(roundedSubTotal)}");
            }                                                  
            
        }
        // return moneyReturn;
        decimal moneyToDispense = paymentTotal - money;
        DispenseCash(moneyToDispense);
    }//function end    

    //PROCESS CREDIT CARD
    public void creditAccepter(decimal money) {
        bool isTrue = true;

        do {
            decimal cardNumber = TryInputDecimal("enter credit number: ");
            bool validationCard = checkValidation(cardNumber.ToString());
            if (validationCard == false) {
                Console.WriteLine("Enter a valid card number: " );
            } else if(validationCard == true) {
                char firstDigit = cardNumber.ToString()[0];
                if (firstDigit == '3') {
                    Console.WriteLine("American Express");
                } else if (firstDigit == '4') {
                    Console.WriteLine("Visa");
                } else if (firstDigit == '5') {
                    Console.WriteLine("Mastercard");
                } else if (firstDigit == '6') {
                    Console.WriteLine("Discover");
                }

                string cashBack = Input("do you want cashback Y/N : ");
                cashBack =cashBack.ToUpper();
                if (cashBack == "Y") {
                    decimal moneyBack = TryInputDecimal("enter cashback amount : ");
                    money = (moneyBack + money);
                    string[] result = MoneyRequest(cardNumber.ToString(), (decimal)money);
                    if (result[1] == "declined") {
                        money = money - moneyBack;
                        Console.WriteLine("declined");
                        Chooser(money);
                    }
                    else if (Math.Round(Convert.ToDecimal(result[1]), 2) > 0) {
                        if (Convert.ToDecimal(result[1]) == money) {
                            Console.WriteLine("Processing");
                            Console.WriteLine("balance paid in full");
                            Console.WriteLine($"cashback {moneyBack}");
                            DispenseCash(moneyBack);
                        } else if (Math.Round(Convert.ToDecimal(result[1]), 2) != Math.Round(money,2)) {
                            //Console.WriteLine(result[1]);
                            money = money - moneyBack;
                            decimal moneyLeft = money - Math.Round(Convert.ToDecimal(result[1]), 2);
                            Console.WriteLine("cashback rejected");
                            Console.WriteLine($"card paid {Math.Round( Convert.ToDecimal(result[1]),2)}");
                            Console.WriteLine($"remaining balance : {moneyLeft}");
                            moneyLeft = Math.Round(moneyLeft, 2);
                            moneyTaker(moneyLeft);
                        }
                    }
                }
                else if(cashBack == "N") {
                    string[] result2 = MoneyRequest(cardNumber.ToString(), money);
                    if (result2[1] == "declined") {
                        Console.WriteLine("declined");
                        Chooser(money);
                    } else if (Math.Round(Convert.ToDecimal(result2[1]), 2) > 0) {
                        if (Math.Round(Convert.ToDecimal(result2[1]), 2) ==Math.Round( money,2)) {
                            Console.WriteLine("Processing");
                            Console.WriteLine("balance paid in full");
                        } else if (Math.Round(Convert.ToDecimal(result2[1]), 2) !=Math.Round( money,2)) {
                            Console.WriteLine($"card paid {Math.Round(Convert.ToDecimal(result2[1]), 2)}");
                            decimal moneyLeft = money - Math.Round(Convert.ToDecimal(result2[1]), 2);
                            moneyLeft =Math.Round(moneyLeft, 2);
                            Console.WriteLine($"remaining total {moneyLeft}");
                            moneyTaker(moneyLeft);
                        }
                        //Console.WriteLine(result[1]);
                    }                   
                }//elseif end
                isTrue = false; 
            }
        } while (isTrue);//do while end
    } //function end   

    //VALIDATES CREDIT CARD
    static bool checkValidation(String cardNo) {
        int nDigits = cardNo.Length;

        int nSum = 0;
        bool isSecond = false;
        for (int i = nDigits - 1; i >= 0; i--) {

            int d = cardNo[i] - '0';

            if (isSecond == true)
                d = d * 2;

            // We add two digits to handle
            // cases that make two digits 
            // after doubling
            nSum += d / 10;
            nSum += d % 10;

            isSecond = !isSecond;
        }
        return (nSum % 10 == 0);
    }

    static string[] MoneyRequest(string account_number, decimal amount) {
            Random rnd = new Random();
            //50% CHANCE TRANSACTION PASSES OR FAILS
            bool pass = rnd.Next(100) < 50;
            //50% CHANCE THAT A FAILED TRANSACTION IS DECLINED
            bool declined = rnd.Next(100) < 50;
            if (pass) {
                return new string[] { account_number, amount.ToString() };
            } else {
                if (!declined) {
                    return new string[] { account_number, (amount / rnd.Next(2, 6)).ToString() };
                } else {
                    return new string[] { account_number, "declined" };
                }//end if
            }//end if
        }//end if
        
            

    
    /*public void InsertMoney() {

    }*/
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

    static double InputDouble(string message) {
        string value = Input(message);
        return double.Parse(value);
    }//function end
    static string Input(string message) {
        Console.Write(message);
        return Console.ReadLine();
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
}//classEnd




