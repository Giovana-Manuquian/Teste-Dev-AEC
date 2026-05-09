# Teste prático — Desenvolvedor C#

Solução em **ASP.NET Core MVC** para o desafio técnico: autenticação, **CRUD de endereços**, integração com **ViaCEP** e **exportação CSV**, persistindo em **SQL Server** via **Entity Framework Core**.

## Funcionalidades

- **Login**: autenticação com validação de credenciais e redirecionamento para a área de endereços.
- **Endereços**: cadastro, listagem, edição e exclusão (por usuário logado).
- **ViaCEP**: ao informar o CEP (8 dígitos), os campos de endereço são preenchidos automaticamente nas telas de criar/editar.
- **CSV**: exportação dos endereços do usuário logado.

## Tecnologias

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core + SQL Server
- HTML, CSS e JavaScript
- API ViaCEP: [viacep.com.br](https://viacep.com.br/)

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server ou **LocalDB** (a connection string padrão usa `(localdb)\mssqllocaldb`)
- Visual Studio 2022 **ou** VS Code + C# Dev Kit (opcional)

## Banco de dados

O script de criação das tabelas `Usuarios` e `Enderecos` está em:

- `Scripts/CriacaoBanco.sql` (neste repositório)  
  Se na sua cópia o arquivo estiver só como `CriacaoBanco.sql` na raiz, use esse caminho.

**Importante:** execute o script no **mesmo banco** configurado em `ConnectionStrings:DefaultConnection` no `appsettings.json` (por padrão o nome do banco é `TesteDevAEC`). Se a tabela já existir com colunas antigas, alinhe o schema ao script ou recrie as tabelas em ambiente de desenvolvimento.

### Observação sobre “senha” no enunciado

A tabela `Usuarios` armazena **hash e salt** da senha (não a senha em texto). Isso atende ao requisito de autenticação com abordagem mais segura.

## Como executar

1. Clone o repositório:

   ```bash
   git clone https://github.com/Giovana-Manuquian/Teste-Dev-AEC.git
   cd Teste-Dev-AEC
   ```

2. Abra o projeto no Visual Studio (arquivo `TesteDevAEC.csproj`) **ou**, na pasta onde esse arquivo estiver, execute:

   ```bash
   dotnet restore
   dotnet run
   ```

3. Ajuste `appsettings.json` se seu SQL Server não for LocalDB ou se o nome do banco for outro.

4. Execute o script SQL (`Scripts/CriacaoBanco.sql` no banco configurado.

5. Com a aplicação em execução em ambiente **Development**, crie o usuário de teste acessando no navegador:

   `https://localhost:<porta>/dev/seed`

   (A rota `/dev/seed` só responde em Development.)

6. Faça login com as credenciais padrão (ou as definidas em `appsettings.Development.json` em `SeedUser`):

   - **Login:** `giovana`
   - **Senha:** `123456`

## Uso rápido

- **Login:** `/Login`
- **Endereços:** `/Endereco` (após autenticar)
- **Exportar CSV:** botão “Exportar CSV” na listagem de endereços

O campo **complemento** é opcional no cadastro.

---

Desenvolvido por **Giovana Manuquian** para o processo seletivo **AEC**.
