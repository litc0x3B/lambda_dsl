using lambda_dsl.LambdaParser;

var parser = new LambdaParserParser();
var root = parser.Parse(@"(\x.(\y.xy))w");
Console.WriteLine($"Your input: {root}");
Console.WriteLine($"Evaluated: {root.Eval()}");