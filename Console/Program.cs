// See https://aka.ms/new-console-template for more information

using AppService;
using DataService;
using OrderService;

var waiter = new Waiter();
var dataService = new DummyDataService();

var cafe = new ConsoleCafe(waiter, dataService);

cafe.ReceiveCustomer();
