using System;
namespace BankAccountManagementSystem;

enum AccountTypes
{
    Savings,
    Checking,
    Business
}

class BankAccount
{
    private int _accountNumber;
    private string _ownerName;
    private double _balance;
    private AccountTypes _accountType;
    private bool _isActive;
    private List<string> _transactionHistory;

    public int AccountNumber
    {
        get => _accountNumber;
    }

    public string OwnerName
    {
        get => _ownerName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _ownerName = "Unknown";
            }
            else
            {
                _ownerName = value;
            }
        }
    }


    public double Balance
    {
        get => _balance;
        set
        {
            if (value < 0)
            {
                _balance = 0;
            }
            else
            {
                _balance = value;
            }
        }
    }


    public string AccountType
    {
        get => _accountType.ToString();
        set
        {
            if (Enum.TryParse<AccountTypes>(value, true, out AccountTypes result))
            {
                _accountType = result;
            }
            else
            {
                _accountType = AccountTypes.Checking;
            }
        }
    }


    public bool IsActive
    {
        get => _isActive;
        private set
        {
            if (value)
            {
                _isActive = true;
            }
            else
            {
                _isActive = false;
            }
        }
    }


    public BankAccount(int accountNumber, string ownerName, double balance, string accountType)
    {
        _accountNumber = accountNumber;
        OwnerName = ownerName;
        Balance = balance;
        AccountType = accountType;
        _isActive = true;
        _transactionHistory = new List<string>();
        Console.WriteLine("hello from full");
    }

    public BankAccount(int accountNumber, string ownerName):this(accountNumber, ownerName, 0.0, "")
    {
        Console.WriteLine("hello from short");
    }

    public override string ToString()
    {
        return $"Account #{AccountNumber} | Owner: {OwnerName} | Balance: ${Balance} | Type: {AccountType:F2}";
    }

    public void Deposit(double amount)
    {
        if (IsActive == false)
        {
            Console.WriteLine("Error: The accound does not active");
        }
        else if (amount > 0)
        {
            Balance = Balance + amount;
            string message = $"Depositing ${amount} to account #{AccountNumber}";
            Console.WriteLine(message);
            _transactionHistory.Add(message);
        }
        else
        {
            Console.WriteLine("Error: The amount is less then zero");
        }
    }

    public bool Withdraw(double amount)
    {
        if (IsActive == false)
        {
            Console.WriteLine("Error: The accound does not active");
            return false;
        }
        else if (amount > 0 && Balance >= amount)
        {
            Balance = Balance - amount;
            string message = $"Withdrawing ${amount} from account #{AccountNumber}";
            Console.WriteLine(message);
            _transactionHistory.Add(message);
            return true;
        }
        else if (amount < 0)
        {
            Console.WriteLine("Error: amount < 0. Cennout withdrow");
            return false;
        }
        else
        {
            Console.WriteLine("Error: amount < balance.");
            return false;
        }
    }

    public void ApplyInterest()
    {
        if (AccountType == AccountTypes.Savings.ToString())
        {
            Balance = Balance + Balance / 50;
        }
        else
        {

        }
    }

    public void PrintTransactionHistory()
    {
        foreach(string message in _transactionHistory)
        {
            Console.WriteLine(message);
        }
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    static void Main()
    {
        List<BankAccount> bankAcounts = new List<BankAccount>();
        BankAccount account1 = new BankAccount(1, "jonn");
        BankAccount account2 = new BankAccount(2, "bob", 100.555, "business");
        Console.WriteLine(account1.ToString());
        account1.Deposit(50);
        Console.WriteLine(account1.ToString());
        account1.Withdraw(40);
        Console.WriteLine(account1.ToString());
        account1.PrintTransactionHistory();
    }
}