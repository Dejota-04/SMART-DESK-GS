
# 🏴‍☠️ Rei dos Piratas - Painel Administrativo (MVP Sprint)

## Sobre esta Aplicação

Este repositório contém o **MVP (Produto Mínimo Viável)** de um painel administrativo para o e-commerce de mangás "Rei dos Piratas". A aplicação foi desenvolvida em **ASP.NET Core MVC** como parte da "Challenge Sprint" da faculdade pelo grupo CATECH.

O foco desta aplicação é fornecer uma interface web completa para o **Gerenciamento de Produtos (CRUD)**, permitindo que um administrador controle o catálogo da loja. Diferente de um protótipo simples, esta aplicação utiliza uma arquitetura robusta com persistência de dados real, conectando-se a um banco de dados **Oracle** através do **Entity Framework Core (EF Core)**.

## ✨ Funcionalidades Implementadas

### Gerenciamento Completo de Produtos (CRUD):

-   **Create:** Formulário otimizado para cadastrar novos mangás.
    
-   **Read:**
    
    -   **Página de Gerenciamento (`/mangas`):** Tabela de produtos com paginação, busca por termo e ordenação por colunas (Nome, Preço, Estoque).
        
    -   **Página de Detalhes:** Visualização completa e estilizada de um único produto.
        
-   **Update:** Formulário de edição que carrega os dados existentes do banco.
    
-   **Delete:** Função de exclusão segura com confirmação em JavaScript (`confirm`).
    

### Persistência de Dados com Banco Real (Oracle):

-   **Conexão Real:** A aplicação se conecta a um banco de dados Oracle, gerenciado pelo Entity Framework Core.
    
-   **Mapeamento (ORM):** Uso do `ApplicationDbContext` e classes de `Model` (`Produto.cs`) com Data Annotations (`[Table]`, `[Column]`) para mapear as tabelas do Oracle.
    
-   **Tratamento de Erros de Banco:** O código inclui lógica `try-catch` para exceções específicas do banco (ex: `OracleException`, `DbUpdateException`), impedindo a aplicação de quebrar e informando o usuário (via `TempData`) sobre erros de integridade (ex: tentar excluir um produto que já está em um pedido).
    

### Validação de Formulários (pt-BR):

-   Mensagens de erro de validação customizadas e traduzidas para o português (`[Required]`, `[StringLength]`).
    
-   Configuração de **Globalização (pt-BR)** no `Program.cs` para que o servidor (`Model Binder`) e o cliente (`jQuery Validate`) aceitem corretamente o formato de números brasileiro (ex: **29,9**).
    

### Interface Administrativa Responsiva:

-   Layout que se adapta a diferentes tamanhos de tela (desktop, tablet, mobile) utilizando Bootstrap 5.
    

## 🛠️ Tecnologias Utilizadas

-   **Backend:** ASP.NET Core 8 MVC, C# 11
    
-   **ORM:** Entity Framework Core 8
    
-   **Banco de Dados:** Oracle Database
    
-   **Frontend:** HTML5, CSS3, JavaScript
    
-   **Framework CSS:** Bootstrap 5
    
-   **Bibliotecas JS:** jQuery & jQuery Validate
    
-   **Ambiente de Desenvolvimento:** Visual Studio 2022
    

## 🚀 Como Executar a Aplicação

A aplicação requer uma conexão com um banco de dados Oracle para funcionar.

1.  **Clone o Repositório:**
    
    ```
    git clone [https://github.com/Dejota-04/Sprint1.git](https://github.com/Dejota-04/Sprint1.git)
    
    ```
    
2.  **Configure a String de Conexão:**
    
    -   Abra o projeto no Visual Studio.
        
    -   No arquivo `appsettings.json`, localize a seção `ConnectionStrings`.
        
    -   Atualize o valor de `OracleConnection` com os dados de acesso (Data Source, User Id, Password) do seu ambiente Oracle.
        
3.  **Rode as Migrations (Se Necessário):**
    
    -   Se o seu banco ainda não possui as tabelas, abra o "Console do Gerenciador de Pacotes" (Package Manager Console) no VS.
        
    -   Execute o comando: `Update-Database`
        
    -   O EF Core criará as tabelas necessárias (como a `PRODUTOS`) no seu banco.
        
4.  **Execute o Projeto:**
    
    -   Pressione **F5** ou clique no botão ▶️ para iniciar o projeto em modo de depuração.
        
    -   A aplicação estará rodando em `localhost`.
        

## 📂 Estrutura do Projeto

O código está organizado seguindo a arquitetura padrão **Model-View-Controller (MVC)**:

-   **/Models:** Contém as classes de entidade (ex: `Produto.cs`).
    
-   **/ViewModels:** Contém os DTOs para os formulários (ex: `ProdutoCreateViewModel.cs`, `ProdutoEditViewModel.cs`).
    
-   **/Views:** Contém os arquivos `.cshtml` (HTML) da interface.
    
-   **/Controllers:** Contém o `ProdutosController.cs` (com toda a lógica CRUD e rotas de atributo) e o `HomeController.cs`.
    
-   **/Data:** Contém o `ApplicationDbContext.cs`, que define a sessão com o banco de dados.
    
-   **Program.cs:** Arquivo de inicialização que configura os serviços (injeção de dependência do `DbContext`), o pipeline HTTP e a globalização `pt-BR`.
    
-   **appsettings.json:** Armazena a string de conexão do banco de dados.
    

## 💡 Próximos Passos & Evolução

Este MVP é a fundação do painel. Os próximos passos para evoluir esta aplicação incluem:

-   **Sistema de Upload de Imagens:** Substituir o campo de URL de imagem por um upload de arquivo real para um serviço de storage (ex: Azure Blob ou S3).
    
-   **Autenticação e Autorização:** Adicionar uma tela de login (ASP.NET Core Identity) para proteger o painel.
    
-   **Expandir o Domínio:** Adicionar novas entidades e seus respectivos CRUDs (ex: `Clientes`, `Pedidos`, `Categorias`).
    
-   **Criar uma API:** Expor os dados dos produtos através de uma API .NET para ser consumida pelo frontend da loja (cliente final).
    

## 👨‍💻 Integrantes do Grupo CATECH

-   **Daniel Santana Corrêa Batista** [RM559622]
    
-   **Wendell Nascimento Dourado** [RA559336]
    
-   **Jonas de Jesus Campos de Oliveira** [RM561144]
