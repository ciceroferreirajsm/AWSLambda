# Projeto AWS Lambda com .NET Core

Este é um projeto de exemplo que demonstra como criar e implantar uma função AWS Lambda usando o .NET Core. Neste projeto, criaremos uma função Lambda simples que responderá a uma solicitação HTTP.

## Requisitos

Antes de começar, certifique-se de ter o seguinte instalado em sua máquina:

- [.NET Core SDK](https://dotnet.microsoft.com/download) - Versão 3.1 ou superior.
- [AWS CLI](https://aws.amazon.com/cli/) - Para implantação do Lambda e configuração das credenciais AWS.
- [Visual Studio Code](https://code.visualstudio.com/) (opcional) - Um ambiente de desenvolvimento leve e multiplataforma.

## Configuração AWS

Antes de criar a função Lambda, você precisará configurar suas credenciais AWS e um novo projeto no AWS Lambda. Siga estas etapas:

1. Instale a AWS CLI e configure suas credenciais usando o comando `aws configure`.

2. Crie um novo projeto Lambda no [AWS Lambda Console](https://aws.amazon.com/lambda/).

3. Anote o ARN (Amazon Resource Name) da função Lambda que você cria.

## Desenvolvimento

1. Clone este repositório:

   ```bash
   git clone https://github.com/seu-usuario/aws-lambda-dotnet-core.git
   cd aws-lambda-dotnet-core
