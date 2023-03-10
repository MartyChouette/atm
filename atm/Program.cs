using System;
using System.Collections.Generic;
using System.Linq;

namespace atm
{
    class Program
    {
        public class cardHolder
        {
            String cardNumber;
            int pin;
            String firstName;
            String lastName;
            double balance;

            public cardHolder(string cardNumber, int pin, string firstName, string lastName, double balance)
            {
                this.cardNumber = cardNumber;
                this.pin = pin;
                this.firstName = firstName;
                this.lastName = lastName;
                this.balance = balance;
            }

            public String getNumber()
            {
                return cardNumber;
            }

            public int getPin()
            {
                return pin;
            }

            public String getFirstName()
            {
                return firstName;
            }

            public String getLastName()
            {
                return lastName;
            }

            public double getBalance()
            {
                return balance;
            }

            public void setNumber(String newCardNumber)
            {
                cardNumber = newCardNumber;
            }

            public void setPin(int newPin)
            {
                pin = newPin;
            }

            public void setFirstName(String newFirstName)
            {
                firstName = newFirstName;
            }

            public void setLastName(String newLastName)
            {
                lastName = newLastName;
            }

            public void setBalance(double newBalance)
            {
                balance = newBalance;
            }

            static void Main(string[] args)
            {
                void printOptions()
                {
                    Console.WriteLine("Hello choose from the following...");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Show Balance");
                    Console.WriteLine("4 Exit");

                }


                void deposit(cardHolder currentUser)
                {
                    Console.WriteLine("How Much would you like to deposit: ");
                    double deposit = Double.Parse(Console.ReadLine());
                    currentUser.setBalance(deposit + currentUser.balance);
                    Console.WriteLine("Thank you for depositing your new balance is: " + currentUser.getBalance());
                }

                void withdraw(cardHolder currentUser)
                {
                    Console.WriteLine("How Much would you like to withdraw: ");
                    double withdrawal = Double.Parse(Console.ReadLine());

                    if (currentUser.getBalance() < withdrawal)
                    {
                        Console.WriteLine("Sorry insuffiecent funds you dont have that much in your account");

                    }
                    else
                    {
                        currentUser.setBalance(currentUser.balance - withdrawal);
                        Console.WriteLine("Thank you for withdrawing your new balance is: " + currentUser.getBalance());

                    }
                }


                void balance(cardHolder currentUser)
                {
                    Console.WriteLine("Current balance: " + currentUser.getBalance());
                }

                List<cardHolder> cardHolders = new List<cardHolder>();
                cardHolders.Add(new cardHolder("1234564567891234", 1234, "John", "Griffith", 150.31));
                cardHolders.Add(new cardHolder("1234912345645678", 4321, "Ashley", "Jones", 321.21));
                cardHolders.Add(new cardHolder("5678912123456434", 9999, "Frida", "Dickerson", 667.02));
                cardHolders.Add(new cardHolder("6789123123456454", 2468, "Maleeb", "Harding", 1238.87));
                cardHolders.Add(new cardHolder("4567891212345634", 8642, "Dawn", "Smith", 2554.28));


                //prompt the user
                Console.WriteLine("Welcome to the ATM");
                Console.WriteLine("please insert card: ");
                String debitCardNumber = "";
                cardHolder currentUser;


                while (true)
                {
                    try
                    {
                        debitCardNumber = Console.ReadLine();
                        //check against
                        currentUser = cardHolders.FirstOrDefault(args => args.cardNumber == debitCardNumber);
                        if (currentUser != null)
                        { break; }
                        else
                        { Console.WriteLine("Card not recognized. Please try again"); }
                    }
                    catch { Console.WriteLine("Card not recognized. Please try again"); }
                }

                Console.WriteLine("Please enter pin: ");
                int userPin = 0;
                while (true)
                {
                    try
                    {
                        userPin = int.Parse(Console.ReadLine());
                        //check against

                        if (currentUser.getPin() == userPin)
                        { break; }
                        else
                        { Console.WriteLine("incorrect pin  Please try again"); }
                    }
                    catch { Console.WriteLine("incorrect pin. Please try again"); }
                }

                Console.WriteLine("Welcome " + currentUser.getFirstName() + " : ");
                int option = 0;
                do
                {
                    printOptions();
                    try
                    {
                        option = int.Parse(Console.ReadLine());
                    }
                    catch { }
                    if (option == 1)
                    { deposit(currentUser); }
                    else if (option == 2)
                    { withdraw(currentUser); }
                    else if (option == 3)
                    { balance(currentUser); }
                    else if (option == 4)
                    { break; }
                    else { option = 0; }
                }
                while (option != 4);
                Console.WriteLine("Thank you for visiting us, have a great day!");

            }



        }
    }
}
