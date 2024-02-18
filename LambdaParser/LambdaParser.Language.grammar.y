%namespace lambda_dsl.LambdaParser
%partial
%parsertype LambdaParserParser
%visibility internal
%tokentype Token

%{
       using LambdaSyntaxTree
%}

%union { 
              public char Id;
              public NodeExpr Expr;
	}


%start ExpressionList

%token LAMBDA, ID, P_OPEN, P_CLOSE, DOT

%%

ExpressionList       : ExpressionList Expression                      {$$.Expr = new NodeAppl($1.Expr, $2.Expr); _treeRoot = $$.Expr;}   
                     | Expression                                     {$$.Expr = $1.Expr}
                     ;

Expression           : ID                                             {$$.Expr = new NodeId($1.Id);}                                     
                     | P_OPEN LAMBDA DOT ID ExpressionList P_CLOSE    {$$.Expr = new NodeAbstr(new NodeId($4.Id), $5.Expr);} 
                     ;

%%