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
        // Scenario: Add single VIP customer and serve immediately
        // Expected Result: VIP customer is served first
        Console.WriteLine("Test 1");
        var service = new CustomerService(4);
        service.AddNewCustomer();
        service.ServeCustomer();
        // Defet(s) Found: none

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add three customers and serve two, leaving one in the queue
        // Expected Result: Customers served in FIFO order; last customer remains
        Console.WriteLine("Test 2");
        service = new CustomerService(5);
        Console.WriteLine("Enter first customer:");
        service.AddNewCustomer(); // e.g., Name: Ethan, Account: 502, Problem: "Cannot reset password"
        Console.WriteLine("Enter second customer:");
        service.AddNewCustomer(); // e.g., Name: Fiona, Account: 503, Problem: "Software crash"
        Console.WriteLine("Enter third customer:");
        service.AddNewCustomer(); // e.g., Name: George, Account: 504, Problem: "Network issue"
        Console.WriteLine($"Before serving customers: {service}");
        service.ServeCustomer(); // Serve Ethan
        service.ServeCustomer(); // Serve Fiona
        Console.WriteLine($"After serving two customers: {service}");

        // Test 3
        // Scenario: Try to serve a customer from an empty queue
        // Expected Result: Should display an error message
        Console.WriteLine("Test 3");
        service = new CustomerService(2);
        service.ServeCustomer(); // Queue is empty
        // Defect(s) Found: Fixed empty queue check
        Console.WriteLine("=================");

        // Test 4
        // Scenario: Test queue overflow by adding customers beyond max size
        // Expected Result: Last customer should trigger an error message
        Console.WriteLine("Test 4");
        service = new CustomerService(2);
        Console.WriteLine("Enter first customer for Test 4:");
        service.AddNewCustomer(); // e.g., Hannah
        Console.WriteLine("Enter second customer for Test 4:");
        service.AddNewCustomer(); // e.g., Ian
        Console.WriteLine("Attempt to add third customer for Test 4 (should fail):");
        service.AddNewCustomer(); // e.g., Jack
        Console.WriteLine($"Service Queue after attempts: {service}");
        // Defect(s) Found: Fixed >= check in AddNewCustomer
        Console.WriteLine("=================");

        // Test 5
        // Scenario: Create a queue with invalid max size
        // Expected Result: Max size should default to 10
        Console.WriteLine("Test 5");
        service = new CustomerService(-5);
        Console.WriteLine($"Queue created with default max size: {service}");
        // Defect(s) Found: None
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
    private void ServeCustomer() {
       if (_queue.Count <= 0) // Defect 2 - Need to check queue length
        {
            Console.WriteLine("No Customers in the queue");
        }
        else {
            // Need to read and save the customer before it is deleted from the queue
            var customer = _queue[0];
            _queue.RemoveAt(0); // Defect 1 - Delete should be done after
            Console.WriteLine(customer);
        }
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