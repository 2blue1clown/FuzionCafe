// See https://aka.ms/new-console-template for more information

using AppService;
using DataService;
using OrderService;

var waiter = new FuzionWaiter();
var dataService = new DummyDataService();

var cafe = new FuzionCafe(waiter, dataService);

cafe.ReceiveCustomer();
