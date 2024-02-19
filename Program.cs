using lambda_dsl.LambdaParser;
using LambdaSyntaxTree;

string str = @"(\x.x)((\y.y)z)(\w.w)";
Console.WriteLine(str);
var parser = new LambdaParserParser();
var root = parser.Parse(str);
DebugClass.root = root;
Console.WriteLine(root);

static class DebugClass
{
    public static NodeExpr? root;
}