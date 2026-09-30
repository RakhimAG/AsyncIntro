

// 1
async Task ProcessOrderAsync(int orderId)
{
    Console.WriteLine($"Order {orderId} : Started the processing");
    await Task.Delay(2000);
    Console.WriteLine($"Order {orderId} : Finished the processing");
}

var ord1 = ProcessOrderAsync(1);
var ord2 = ProcessOrderAsync(2);
var ord3 = ProcessOrderAsync(3);

await Task.WhenAll([ord1, ord2, ord3]);

// 2
int counter = 0;

async Task IncrementBy1000()
{
    for (int i = 0; i < 1000; i++)
        counter++;
    await Task.Delay(2000);
}
Task[] tasks = new Task[5];
for (int i = 0;i <= 4;i++)
{
    tasks[i] = Task.Run(IncrementBy1000);
}

await Task.WhenAll(tasks);

Console.WriteLine($"Counter => {counter}");
// по идее весь инкремент происходит одновременно
// из-за использования потоков в методе Task.Run(),
// ведь 5 задач выполнились за 2сек а не за 10сек.