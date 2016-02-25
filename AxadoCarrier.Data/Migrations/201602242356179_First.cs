namespace AxadoCarrier.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TbCad_Carrier",
                c => new
                    {
                        cCarrier = c.Int(nullable: false, identity: true),
                        Tipo = c.Int(nullable: false),
                        CpfCnpj = c.String(),
                        NomeRazao = c.String(),
                        RgIe = c.String(),
                        Endereco = c.String(),
                        Numero = c.String(),
                        Bairro = c.String(),
                        Complemento = c.String(),
                        CEP = c.String(),
                        Cidade = c.String(),
                        UF = c.String(),
                        Contato = c.String(),
                        Telefone = c.String(),
                        Celular = c.String(),
                        Email = c.String(),
                        Site = c.String(),
                        Ativa = c.Boolean(nullable: false),
                        cClassificacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cCarrier)
                .ForeignKey("dbo.TbCad_Rating", t => t.cClassificacao, cascadeDelete: true)
                .Index(t => t.cClassificacao);
            
            CreateTable(
                "dbo.TbCad_Rating",
                c => new
                    {
                        cRating = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.cRating);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TbCad_Carrier", "cClassificacao", "dbo.TbCad_Rating");
            DropIndex("dbo.TbCad_Carrier", new[] { "cClassificacao" });
            DropTable("dbo.TbCad_Rating");
            DropTable("dbo.TbCad_Carrier");
        }
    }
}
