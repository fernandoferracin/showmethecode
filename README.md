# DESAFIO TÉCNICO

###### O Desafio é criar duas API's.

## API 1
###### Retorna taxa de Juros
Responde pelo path relativo "/taxaJuros"
Retorna o juros de 1% ou 0,01 (fixo no código)
Exemplo: /taxaJuros Resultado esperado: 0,01

## API 2 
###### Calcula Juros
Responde pelo path relativo "/calculajuros"
Ela faz um cálculo em memória, de juros compostos, conforme formula: Valor Final = Valor Inicial * (1 + juros) ^ Tempo
Valor inicial é um decimal recebido como parâmetro.
Valor do Juros deve ser consultado na API 1.
Tempo é um inteiro, que representa meses, também recebido como parâmetro.
^ representa a operação de potência.
Resultado final deve ser truncado (sem arredondamento) em duas casas decimais.
Exemplo: /calculajuros?valorinicial=100&meses=5 Resultado esperado: 105,10


# SOLUÇÃO
- O desenvolvimento foi feito no visual studio 2019 em Asp.net core.
- A solução:
  - Dois projetos de APIs, **CalculaJuros.API** e **TaxaJuros.API**. (Por se tratar do mesmo contexto, poderia ser somente um projeto e cada API com seu path).
  - Um projeto para camada de negócio, onde foi feito validação (Utilizado FluentValidation), notificação e cálculo, **DesafioTecnico.Business**.
  - Uma camada visual em MVC Core para chamar as API's, **DesafioTecnico.MVC**. (Não foquei muito em validações e tratamento de erros nessa camada, apenas as básicas para o funcionamento)
  - Um projeto de Tests [TDD](docs/TDD.png), **DesafioTecnico.UnitTest**
  - [Visualizar Solution](docs/Solution.png)
- O código fonte foi versionado nesse repósito do github. [Fontes](Fontes)
- Docker:
  - Criado o [docker-compose.yml](Fontes\docker) para as chamadas dos Dockerfile.
  - Criado 4 imagens: 
    - "luisfernandoferracin/showmethecode-mvc" referente a camada de apresentação.
    - "luisfernandoferracin/taxajuros" referente a API 1.
    - "luisfernandoferracin/calculajuros" referente a API 2.
    - "luisfernandoferracin/showmethecode" referente ao nginx.
  - Imagens disponiveis em [Packages](https://github.com/fernandoferracin?tab=packages&repo_name=showmethecode)
    - Obs.: Tentei fazer o build do código pelo [Docker Hub](https://hub.docker.com/) integrado com os fontes do Git Hub mais pelo pouco tempo dispinivel não consegui, dificuldades por conta de utilizar o docker-compose.
  - Docker Desktop:
    - Com o Docker Desktop instalado e configurado corretamente, realizar o dowload dos [fontes](Fontes).
    - Abrir um terminal (pode ser o PowerShell), ir para o diretório "~\Fontes\docker" e executar o comando "docker-compose -f docker-compose.yml up".
    - Após a conclusão as imagens criadas pode ser visualizadas no docker desktop e executada através da imagem do nginx no endereço: https://localhost/
    - [Visualizar resultado](docs/DockerDesktop.png)
  - Swagger:
    - Ambas API estão utilizando Swagger
    - [Visualizar](docs/Swagger.png)
  
