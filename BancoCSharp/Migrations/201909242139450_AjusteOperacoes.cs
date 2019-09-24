namespace BancoCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteOperacoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cpf = c.String(),
                        Nome = c.String(),
                        Endereco = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                        UsuarioId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId_Id)
                .Index(t => t.UsuarioId_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Conta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DigConta = c.Int(nullable: false),
                        Saldo = c.Double(nullable: false),
                        ClienteId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId_Id)
                .Index(t => t.ClienteId_Id);
            
            CreateTable(
                "dbo.Operacaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoOperacao = c.String(),
                        ContaId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conta", t => t.ContaId_Id)
                .Index(t => t.ContaId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operacaos", "ContaId_Id", "dbo.Conta");
            DropForeignKey("dbo.Conta", "ClienteId_Id", "dbo.Cliente");
            DropForeignKey("dbo.Cliente", "UsuarioId_Id", "dbo.Usuario");
            DropIndex("dbo.Operacaos", new[] { "ContaId_Id" });
            DropIndex("dbo.Conta", new[] { "ClienteId_Id" });
            DropIndex("dbo.Cliente", new[] { "UsuarioId_Id" });
            DropTable("dbo.Operacaos");
            DropTable("dbo.Conta");
            DropTable("dbo.Usuario");
            DropTable("dbo.Cliente");
        }
    }
}
