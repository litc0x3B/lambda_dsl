%namespace lambda_dsl.LambdaParser
%scannertype LambdaParserScanner
%visibility internal
%tokentype Token

%option stack, minimize, parser, verbose, persistbuffer, noembedbuffers 

Eol             (\r\n?|\n)
NotWh           [^ \t\r\n]
Space           [ \t]
Id              [a-z]
Lambda          \\
POpen           \(
PClose          \)
Dot             \.

%{

%}

%%

/* Scanner body */

{Id}		{ Console.WriteLine("token: {0}", yytext); GetChar(); return (int)Token.ID; }
{Lambda}	{ Console.WriteLine("token: LAMBDA"); return (int)Token.LAMBDA; }

{Space}+	/* skip */

{POpen}		{ Console.WriteLine("token: {0}", yytext); return (int)Token.P_OPEN; }
{PClose}	{ Console.WriteLine("token: {0}", yytext); return (int)Token.P_CLOSE; }
{Dot}	    { Console.WriteLine("token: {0}", yytext); return (int)Token.DOT; }



%%