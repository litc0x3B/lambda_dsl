namespace LambdaSyntaxTree {
    abstract class NodeExpr {}

    class NodeAppl : NodeExpr 
    {
        public NodeExpr[] Children {get; set;}
        NodeAppl(NodeExpr NodeExprLeft, NodeExpr NodeExprRight)
        {
            Children = [NodeExprLeft, NodeExprRight];
        }
    }

    class NodeAbstr : NodeExpr 
    {
        public NodeId Id {get; set;}
        public NodeExpr Expr {get; set;}
        NodeAbstr(NodeId id, NodeExpr expr)
        {
            Id = id;
            Expr = expr;
        }
    }

    class NodeId : NodeExpr 
    {
        NodeId(char name) 
        {
            Name = name;
        }
        public char Name {get; set;}
    }
}
