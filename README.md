# SGFBA — Sistema de Gerenciamento de Fichas de Busca Ativa

Sistema desenvolvido como Projeto de Extensão (PEX) do curso de **Análise e Desenvolvimento de Sistemas** (Descomplica), com o objetivo de digitalizar e centralizar o registro das **Fichas de Busca Ativa** utilizadas pela Orientação Educacional da **Escola Estadual Indígena Kumanã**, localizada na Aldeia Fontoura, Lagoa da Confusão – TO.

O processo, antes realizado manualmente em papel, gerava acúmulo físico de fichas e dificultava o acesso ao histórico de acompanhamento dos estudantes. O SGFBA propõe uma solução via API para cadastro, atualização e consulta de fichas e ações de busca ativa, com controle de usuários e níveis de permissão.

## ✨ Principais Funcionalidades

- Cadastro, atualização e exclusão de usuários (Administrador, Orientador Educacional, Coordenador Pedagógico, Secretário, Gestor Escolar);
- Autenticação e autorização de usuários (login seguro);
- Cadastro, atualização e exclusão de estudantes;
- Cadastro, atualização e cancelamento de Fichas de Busca Ativa;
- Cadastro, atualização e exclusão de Ações de Busca Ativa vinculadas a uma ficha;
- Consultas de dados essenciais e completos de usuários, estudantes e fichas;
- Consulta de fichas e ações relacionadas a um orientador/coordenador específico;
- Estrutura preparada para geração futura de relatórios em PDF e Excel.


## 🧑‍🤝‍🧑 Perfis de Usuário

| Perfil | Principais permissões |
|---|---|
| Administrador | Gerenciar usuários, validar/conceder/remover permissões |
| Gestor Escolar | Acesso às fichas, gerenciar estudantes, gerar relatórios |
| Secretário | Acesso às fichas, gerenciar estudantes, gerar relatórios |
| Orientador Educacional | Registrar/atualizar fichas e ações, gerenciar seus próprios registros |
| Coordenador Pedagógico | Registrar/atualizar fichas e ações (suas e de orientadores), gerar relatórios |

## 🛠️ Tecnologias Utilizadas

- **C# / .NET 10**
- **ASP.NET Core Web API**
- **Entity Framework Core** (migrations, relacionamentos, *Global Query Filter*)
- **MySQL** (banco de dados relacional)
- **Swagger / Swashbuckle** (documentação e testes de autenticação/autorização da API)
- **DrawSQL** e **BrModelo Web** (modelagem do banco de dados)

## 📐 Modelagem de Dados

A modelagem conceitual e física do banco de dados foi construída a partir do levantamento de requisitos, contemplando as entidades principais:

- **Usuário** — dados de acesso, cargo e nível de permissão;
- **Estudante** — dados escolares e do responsável;
- **Ficha de Busca Ativa** — vinculada a um estudante e a um orientador/coordenador;
- **Ação de Busca Ativa** — vinculada a uma ficha específica.

## 🚀 Como executar o projeto

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/)
- [MySQL Server](https://www.mysql.com/)
- Uma IDE de sua preferência (Visual Studio, VS Code, Rider, etc.)

### Passos

```bash
# Clone o repositório
git clone https://github.com/<seu-usuario>/sgfba.git
cd sgfba

# Restaure as dependências
dotnet restore

# Configure a string de conexão do MySQL em appsettings.json
# "ConnectionStrings": { "DefaultConnection": "Server=localhost;Database=sgfba;User=root;Password=senha;" }

# Aplique as migrations do Entity Framework
dotnet ef database update

# Execute o projeto
dotnet run
```

Após iniciar, a documentação da API estará disponível via Swagger em:

```
https://localhost:{porta}/swagger
```

## 🔒 Autenticação

A API utiliza autenticação/autorização configurada no Swagger, permitindo testar endpoints protegidos diretamente pela interface de documentação, respeitando o nível de permissão de cada usuário.

## 🗺️ Roadmap / Próximas Etapas

- [ ] Geração de relatórios em PDF e Excel das Fichas de Busca Ativa;
- [ ] Testes de unidade e de integração;
- [ ] Solicitação de permissão de acesso diretamente pelo sistema (sem necessidade de e-mail);
- [ ] Interface (front-end) para consumo da API.

## 🎓 Contexto Acadêmico

Este projeto é resultado do **Projeto de Extensão (PEX) — Fase IV** do curso de Análise e Desenvolvimento de Sistemas da Descomplica, relacionando-se aos Objetivos de Desenvolvimento Sustentável (ODS) da ONU:

- **ODS 4** — Educação de Qualidade
- **ODS 10** — Redução das Desigualdades
- **ODS 9** — Indústria, Inovação e Infraestrutura

## 👤 Autor

**Vanilson da Conceição Sousa**
Orientador Educacional — Escola Estadual Indígena Kumanã
Aluno de Análise e Desenvolvimento de Sistemas — Descomplica
📧 vanilsons710@gmail.com

## 📄 Licença

Projeto acadêmico desenvolvido para fins de Extensão Universitária. Uso e adaptação livres mediante citação da fonte.
