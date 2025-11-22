

# 🏢 Smart Desk - Sistema de Gestão Corporativa (.NET 8)

## 📋 Visão Geral Técnica
Este projeto consiste em uma aplicação web desenvolvida em **ASP.NET Core MVC (.NET 8)** para o gerenciamento de colaboradores e chamados de suporte em um ambiente corporativo.

O foco principal desta entrega é a estruturação da arquitetura MVC, implementação do **Entity Framework Core** com banco de dados **Oracle**, criação de rotas personalizadas e validação de dados (Server-side e Client-side).

---

## 👨‍💻 Equipe (Grupo CATECH)
* **Daniel Santana Corrêa Batista** – RM559622
* **Jonas de Jesus Campos de Oliveira** – RM561144
* **Wendell Nascimento Dourado** – RM559336

---

## 🛠️ Stack Tecnológica & Decisões Arquiteturais

### 1. Camada de Apresentação (Web Layer)
* **ASP.NET Core MVC:** Utilizado para separação clara de responsabilidades.
* **Razor Views:** Interface do usuário com **Bootstrap 5** para layout responsivo.
* **Tag Helpers:** Utilizados extensivamente para formulários e links (`asp-controller`, `asp-for`).
* **ViewData & TempData:** Implementados para transporte de dados temporários (mensagens de feedback "Toast") e preenchimento de Dropdowns (`SelectList`).

### 2. Camada de Dados (Infra & Data)
* **Entity Framework Core:** ORM utilizado para abstração do acesso a dados.
* **Mapeamento Objeto-Relacional:** Configurado explicitamente no `DbContext` para garantir compatibilidade com o Oracle Database, resolvendo conflitos de *Case Sensitivity* (nomes de tabelas e colunas em maiúsculo).
* **Enum Conversion:** Configuração do EF Core para converter `Enums` (Status, Role) para `Strings` no banco de dados, aumentando a legibilidade dos dados.

### 3. Regras de Negócio & Validações
* **Data Annotations:** Modelos (`Usuario`, `Suporte`) decorados com atributos como `[Required]`, `[StringLength]` e `[EmailAddress]` para garantir a integridade na entrada.
* **Soft Deletes (Lógica):** Implementação de restrições de chave estrangeira (`DeleteBehavior.Restrict`) para impedir a exclusão de usuários que possuem histórico de atendimentos.

---

## 🚀 Como Rodar o Projeto

### Pré-requisitos
* .NET SDK 8.0
* Acesso ao Banco de Dados Oracle.

### 1. Configuração de Conexão
Abra o arquivo `appsettings.json` e configure a string de conexão `OracleConnection` com suas credenciais:

```json
"ConnectionStrings": {
  "OracleConnection": "User Id=SEU_USER;Password=SUA_SENHA;Data Source=oracle.fiap.com.br:1521/ORCL"
}
```

### 2. Banco de Dados (Migrations)

O projeto utiliza EF Core Migrations. Caso precise inicializar o banco:

Bash

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 3. Execução

No terminal, na pasta raiz do projeto:

Bash

```
dotnet run
```

Acesse via navegador em: `https://localhost:7166`

----------


## 🔗 Rotas da Aplicação

A aplicação utiliza o roteamento padrão do MVC (`{controller}/{action}/{id?}`) e inclui **Rotas Personalizadas** conforme requisito da disciplina:

| Funcionalidade | Rota | Tipo | Controller |
| :--- | :--- | :--- | :--- |
| **Dashboard** | `/` | Padrão | `HomeController` |
| **Listar Usuários** | `/Usuarios` | Padrão | `UsuariosController` |
| **Novo Usuário** | `/Usuarios/Create` | Padrão | `UsuariosController` |
| **Central de Suporte** | `/Suportes` | Padrão | `SuportesController` |
| **Novo Chamado** | `/Atendimento/Novo` | **Personalizada** | `SuportesController` |



_Projeto acadêmico - FIAP 2025._
