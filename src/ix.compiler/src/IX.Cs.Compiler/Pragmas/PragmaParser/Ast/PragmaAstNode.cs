// Ix.Compiler.Cs
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace Ix.Compiler.Cs.Pragmas.PragmaParser;

internal class PragmaAstNode : AstNode
{
    public List<AstNode?>? Children { get; set; }

    public override void Init(AstContext context, ParseTreeNode treeNode)
    {
        Children = treeNode.ChildNodes.Select(p => p.AstNode as AstNode).ToList();
    }

    public override void AcceptVisitor(IAstVisitor visitor)
    {
        this.Children.ForEach(p =>
        {
            if (p != null) p.AcceptVisitor(visitor);
        });

    }
}