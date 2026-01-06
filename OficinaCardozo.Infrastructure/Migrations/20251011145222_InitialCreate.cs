using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OficinaCardozo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OFICINA_CLIENTE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NOME = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TELEFONE_PRINCIPAL = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    EMAIL_PRINCIPAL = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ENDERECO_PRINCIPAL = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFICINA_CLIENTE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OFICINA_ORCAMENTO_STATUS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DESCRICAO = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFICINA_ORCAMENTO_STATUS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OFICINA_ORDEM_SERVICO_STATUS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DESCRICAO = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFICINA_ORDEM_SERVICO_STATUS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OFICINA_PECA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NOME_PECA = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    CODIGO_IDENTIFICADOR = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PRECO = table.Column<decimal>(type: "TEXT", nullable: false),
                    QTD_ESTOQUE = table.Column<int>(type: "INTEGER", nullable: false),
                    QTD_MINIMA = table.Column<int>(type: "INTEGER", nullable: false),
                    UNIDADE_MEDIDA = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LOCALIZACAO_ESTOQUE = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    OBSERVACOES = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFICINA_PECA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OFICINA_SERVICO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NOME_SERVICO = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    PRECO = table.Column<decimal>(type: "TEXT", nullable: false),
                    TEMPO_ESTIMADO_EXECUCAO = table.Column<int>(type: "INTEGER", nullable: false),
                    DESCRICAO_DETALHADA_SERVICO = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    FREQUENCIA_RECOMENDADA = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFICINA_SERVICO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OFICINA_USUARIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NOME_USUARIO = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    EMAIL = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    HASH_SENHA = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    COMPLEXIDADE = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    DATA_CRIACAO = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFICINA_USUARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OFICINA_VEICULO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID_CLIENTE = table.Column<int>(type: "INTEGER", nullable: false),
                    PLACA = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    MARCA_MODELO = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ANO_FABRICACAO = table.Column<int>(type: "INTEGER", nullable: false),
                    COR = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TIPO_COMBUSTIVEL = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFICINA_VEICULO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OFICINA_VEICULO_OFICINA_CLIENTE_ID_CLIENTE",
                        column: x => x.ID_CLIENTE,
                        principalTable: "OFICINA_CLIENTE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OFICINA_ORDEM_SERVICO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DATA_SOLICITACAO = table.Column<long>(type: "INTEGER", nullable: false),
                    ID_VEICULO = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_STATUS = table.Column<int>(type: "INTEGER", nullable: false),
                    DATA_FINALIZACAO = table.Column<long>(type: "INTEGER", nullable: true),
                    DATA_ENTREGA = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFICINA_ORDEM_SERVICO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OFICINA_ORDEM_SERVICO_OFICINA_ORDEM_SERVICO_STATUS_ID_STATUS",
                        column: x => x.ID_STATUS,
                        principalTable: "OFICINA_ORDEM_SERVICO_STATUS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OFICINA_ORDEM_SERVICO_OFICINA_VEICULO_ID_VEICULO",
                        column: x => x.ID_VEICULO,
                        principalTable: "OFICINA_VEICULO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OFICINA_ORCAMENTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DATA_ORCAMENTO = table.Column<long>(type: "INTEGER", nullable: false),
                    ID_ORDEM_SERVICO = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_STATUS = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFICINA_ORCAMENTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OFICINA_ORCAMENTO_OFICINA_ORCAMENTO_STATUS_ID_STATUS",
                        column: x => x.ID_STATUS,
                        principalTable: "OFICINA_ORCAMENTO_STATUS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OFICINA_ORCAMENTO_OFICINA_ORDEM_SERVICO_ID_ORDEM_SERVICO",
                        column: x => x.ID_ORDEM_SERVICO,
                        principalTable: "OFICINA_ORDEM_SERVICO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OFICINA_ORDEM_SERVICO_PECA",
                columns: table => new
                {
                    ID_PECA = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_ORDEM_SERVICO = table.Column<int>(type: "INTEGER", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "INTEGER", nullable: false),
                    VALOR_UNITARIO = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFICINA_ORDEM_SERVICO_PECA", x => new { x.ID_ORDEM_SERVICO, x.ID_PECA });
                    table.ForeignKey(
                        name: "FK_OFICINA_ORDEM_SERVICO_PECA_OFICINA_ORDEM_SERVICO_ID_ORDEM_SERVICO",
                        column: x => x.ID_ORDEM_SERVICO,
                        principalTable: "OFICINA_ORDEM_SERVICO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OFICINA_ORDEM_SERVICO_PECA_OFICINA_PECA_ID_PECA",
                        column: x => x.ID_PECA,
                        principalTable: "OFICINA_PECA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OFICINA_ORDEM_SERVICO_SERVICO",
                columns: table => new
                {
                    ID_ORDEM_SERVICO = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_SERVICO = table.Column<int>(type: "INTEGER", nullable: false),
                    VALOR_APLICADO = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFICINA_ORDEM_SERVICO_SERVICO", x => new { x.ID_ORDEM_SERVICO, x.ID_SERVICO });
                    table.ForeignKey(
                        name: "FK_OFICINA_ORDEM_SERVICO_SERVICO_OFICINA_ORDEM_SERVICO_ID_ORDEM_SERVICO",
                        column: x => x.ID_ORDEM_SERVICO,
                        principalTable: "OFICINA_ORDEM_SERVICO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OFICINA_ORDEM_SERVICO_SERVICO_OFICINA_SERVICO_ID_SERVICO",
                        column: x => x.ID_SERVICO,
                        principalTable: "OFICINA_SERVICO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
			table: "OFICINA_ORCAMENTO_STATUS",
			columns: new[] { "ID", "DESCRICAO" },
			values: new object[,]
			{
				{ 1, "Criado" },
				{ 2, "Pendente aprovacao" },    
				{ 3, "Aprovado" },
				{ 4, "Rejeitado" },
				{ 5, "Em elaboracao" }          
			});

			migrationBuilder.InsertData(
			table: "OFICINA_ORDEM_SERVICO_STATUS",
			columns: new[] { "ID", "DESCRICAO" },
			values: new object[,]
			{
				{ 1, "Recebida" },
				{ 2, "Em diagnostico" },        
				{ 3, "Aguardando aprovacao" },  
				{ 4, "Em execucao" },           
				{ 5, "Finalizada" },
				{ 6, "Entregue" },
				{ 7, "Em elaboracao" },         
				{ 8, "Cancelada" },
				{ 9, "Devolvida" }
			});

            migrationBuilder.CreateIndex(
                name: "IX_OFICINA_ORCAMENTO_ID_ORDEM_SERVICO",
                table: "OFICINA_ORCAMENTO",
                column: "ID_ORDEM_SERVICO");

            migrationBuilder.CreateIndex(
                name: "IX_OFICINA_ORCAMENTO_ID_STATUS",
                table: "OFICINA_ORCAMENTO",
                column: "ID_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_OFICINA_ORDEM_SERVICO_ID_STATUS",
                table: "OFICINA_ORDEM_SERVICO",
                column: "ID_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_OFICINA_ORDEM_SERVICO_ID_VEICULO",
                table: "OFICINA_ORDEM_SERVICO",
                column: "ID_VEICULO");

            migrationBuilder.CreateIndex(
                name: "IX_OFICINA_ORDEM_SERVICO_PECA_ID_PECA",
                table: "OFICINA_ORDEM_SERVICO_PECA",
                column: "ID_PECA");

            migrationBuilder.CreateIndex(
                name: "IX_OFICINA_ORDEM_SERVICO_SERVICO_ID_SERVICO",
                table: "OFICINA_ORDEM_SERVICO_SERVICO",
                column: "ID_SERVICO");

            migrationBuilder.CreateIndex(
                name: "IX_OFICINA_VEICULO_ID_CLIENTE",
                table: "OFICINA_VEICULO",
                column: "ID_CLIENTE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OFICINA_ORCAMENTO");

            migrationBuilder.DropTable(
                name: "OFICINA_ORDEM_SERVICO_PECA");

            migrationBuilder.DropTable(
                name: "OFICINA_ORDEM_SERVICO_SERVICO");

            migrationBuilder.DropTable(
                name: "OFICINA_USUARIO");

            migrationBuilder.DropTable(
                name: "OFICINA_ORCAMENTO_STATUS");

            migrationBuilder.DropTable(
                name: "OFICINA_PECA");

            migrationBuilder.DropTable(
                name: "OFICINA_ORDEM_SERVICO");

            migrationBuilder.DropTable(
                name: "OFICINA_SERVICO");

            migrationBuilder.DropTable(
                name: "OFICINA_ORDEM_SERVICO_STATUS");

            migrationBuilder.DropTable(
                name: "OFICINA_VEICULO");

            migrationBuilder.DropTable(
                name: "OFICINA_CLIENTE");
        }
    }
}
