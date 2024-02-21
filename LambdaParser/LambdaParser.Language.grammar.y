%namespace lambda_dsl.LambdaParser
%partial
%parsertype LambdaParserParser
%visibility internal
%tokentype Token
%using LambdaSyntaxTree;


%union { 
              public char Id;
              public NodeExpr Expr;
	}


%start TermList

%token LAMBDA, ID, P_OPEN, P_CLOSE, DOT

%%

TermList             : TermList Term                           {$$.Expr = new NodeAppl($1.Expr, $2.Expr); _treeRoot = $$.Expr;}   
                     | Term                                    {$$.Expr = $1.Expr; _treeRoot = $$.Expr;}
                     ;

Term                 : P_OPEN TermList P_CLOSE                 {$$.Expr = $2.Expr;}
                     | Expression                              {$$.Expr = $1.Expr;}
                     ;

Expression           : ID                                      {$$.Expr = new NodeId($1.Id);}                                     
                     | P_OPEN LAMBDA ID DOT TermList P_CLOSE   {$$.Expr = new NodeAbstr(new NodeId($3.Id), $5.Expr);} 
                     ;

%%

private NodeExpr _treeRoot;