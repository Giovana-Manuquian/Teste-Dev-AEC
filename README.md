# Teste Prático - Desenvolvedor C#

Este repositório contém a solução para o desafio técnico de desenvolvimento web em C#. O objetivo é gerenciar um CRUD de endereços com autenticação de usuário e integração com a API ViaCEP.

## 🚀 Funcionalidades
- **Autenticação**: Sistema de login com validação de credenciais.
- **Gerenciamento de Endereços**: CRUD completo (Adicionar, Visualizar, Editar e Excluir).
- **Integração ViaCEP**: Busca automática de dados de endereço ao informar o CEP.
- **Exportação CSV**: Funcionalidade para exportar a lista de endereços salvos em formato .csv.

## 🛠 Tecnologias Utilizadas
- **Backend**: ASP.NET Core MVC
- **ORM**: Entity Framework Core
- **Banco de Dados**: SQL Server
- **Frontend**: HTML5, CSS3 e JavaScript (Puro)
- **API Externa**: ViaCEP (https://viacep.com.br/)

## 📂 Estrutura do Banco de Dados
Os scripts de criação das tabelas `Usuarios` e `Enderecos` estão localizados na raiz do projeto no arquivo:
- `Scripts/CriacaoBanco.sql`

## ⚙️ Como Executar o Projeto
1. Clone este repositório:
   ```bash
   git clone [https://github.com/SEU-USUARIO/NOME-DO-REPOSITORIO.git](https://github.com/SEU-USUARIO/NOME-DO-REPOSITORIO.git)
2. Execute o script SQL no seu SQL Server para criar a estrutura das tabelas.

3. Abra a solução no Visual Studio 2022.

4. No arquivo appsettings.json, atualize a ConnectionStrings com os dados do seu servidor local.

5. Pressione F5 para rodar a aplicação.

Desenvolvido por Giovana Manuquian para o processo seletivo AEC.