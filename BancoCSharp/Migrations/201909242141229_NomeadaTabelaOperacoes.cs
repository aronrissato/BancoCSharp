namespace BancoCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomeadaTabelaOperacoes : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Operacaos", newName: "Operacao");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Operacao", newName: "Operacaos");
        }
    }
}
