/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Create a queue with invalid size
        // Expected Result: empty queue
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(0);
        Console.WriteLine(cs1);


        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add clients to the queue to surpass the limit
        // Expected Result: 
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(2);
        cs2.AddNewCustomer();
        Console.WriteLine(cs2);


        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        //test 3
        //scenario: Queue full
        //Expected result: Should display error message
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(1);
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();

        //Defect(s) found: queue overflow bug
        Console.WriteLine("Maximum Number of Customers in Queue.");

        //test 4
        //scenario: Serve customer 
        //Expected result: First custumer removed and displayed
        Console.WriteLine("Test 4");
        var cs4 = new CustomerService(3);
        cs4.AddNewCustomer();
        cs4.ServeCustomer();

        //Defect(s) found: Incorreted customer served
        Console.WriteLine("=================");

        //test 5
        //scenario: Empty queue
        //Expected result: Should display error message
        Console.WriteLine("Test 5");
        var cs5 = new CustomerService(3);
        cs5.ServeCustomer();

        //Defect(s) found: show one message more than needed
        Console.WriteLine("=================");


    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count > _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() 
    {
        if (_queue.Count == 0) 
        {
            Console.WriteLine("No customers in the queue.");
            return;
        }
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}