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
    private bool _isActive = true;
    private List<string>? _transactionHistory;

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
        Console.WriteLine("hello from full");
    }

    public BankAccount(int accountNumber, string ownerName):this(accountNumber, ownerName, 0.0, "")
    {
        Console.WriteLine("hello from short");
    }

    public override string ToString()
    {
        return $"Account #{AccountNumber} | Owner: {OwnerName} | Balance: ${Balance} | Type: {AccountType}";
    }

    static void Main()
    {
        BankAccount account1 = new BankAccount(1, "jonn");
        Console.WriteLine(account1.ToString());
    }
}