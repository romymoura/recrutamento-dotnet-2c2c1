# Recrutamento 7COMm (.Net-2C2C1)

O `recrutamento-dotnet-2c2c1` é um teste aplicado pela [7COMm Serviços e Soluções em TI](https://7comm.com.br) para recrutamento de profissionais `C#`.

## Como funciona a avaliação

O candidato deve fazer um `fork` deste repositório e implementar as funcionalidades solicitadas conforme julgar adequado. A entrega será feita através do repoistório do candidato, que deverá ser informado por email quando concluída a implementação.

## Como será a avaliação

O nível de exigência na avaliação vai variar conforme a senioridade e a oportunidade disponível. O objetivo deste teste é avaliar, primariamente, os seguintes aspectos:

- Uso do `git`, analizando o histórico de commits;
- Nivel de aproveitamento ou refatoração da estrutura proposta na solução disponibilizada neste repositório;
- Uso dos métodos de resposta do `ControllerBase` do `ASP .Net Core` para entrega das respostas das `actions`, incluindo uso adequado do `HTTP Status Code`;
- Aderência a boas prátias e convenções, tanto de arquitetura quanto codificação e nomeação de artefatos;
- Nível de aproveitamento, refatoração ou implementação de testes de unidade;
- Legibilidade do código e nível de complexidade adotada;
- Entre outros.

Consideradas essas questões, o time técnico da [7COMm Serviços e Soluções em TI](https://7comm.com.br) irá avaliar a implementação entregue pelo candidato e entrará em contato para agradecer a particiapação ou para marcar uma entrevista técnica.

## Sobre este repositório

Este repositório possui um esqueleto de solução [`Visual Studio 2017`](https://visualstudio.microsoft.com/downloads/) propondo uma arquitetura `DDD` para disponibilizar uma `API REST` em `ASP .Net Core 2.1` na porta `5001` do `localhost`. Esta solução está com `Swagger` e um projeto para testes de unidade dos `controllers` sugeridos. O `Swagger` adotado é o [`Swashbuckle.AspNetCore`](https://www.nuget.org/packages/swashbuckle.aspnetcore/) e pode ser acessado pela `URL`: [`http://localhost:5001/swagger`](http://localhost:5001/swagger).

### Organização do repositório

O esqueleto disponibilizado neste repositório contempla os seguintes diretórios:

- `pm`: diretório com coleções, variáveis de ambiente e arquivo de injeção de dados do [`Postman`](https://www.getpostman.com/), incluindo um arquivo `bat` com as instruções para instalar e rodar o [`Newman`](https://www.npmjs.com/package/newman). Para utilizar o [`Newman`](https://www.npmjs.com/package/newman) é necessário ter o [`Node.js`](https://nodejs.org/).
- `src`: diretório com o esqueleto de solução proposta para avaliação das rotinas solicitadas.

## O que implementar

Tomando como partida o esqueleto disponibilizado neste repositório, o candidato deve implementar uma `API REST` compatível com os `endpoints` expostos no `Swagger` deste esqueleto proposto. A saber:

- `POST /api/v1/ordena-lista`: recebe uma lista de valores no formato `{ "lista": [ "string" ] }` e devolve esta mesma lista com seus elementos ordenados em ordem alfabética crescente no formato `{ "listaOrdenada": [ "string" ] }`;
- `POST /api/v1/pagina-lista`: recebe o tamanho da página, o índice da página e uma lista de elementos a serem paginados, no formato `{ "lista": [ "string" ], "tamanhoPagina": 0, "indicePagina": 0 }`, e devolve a página solicitada com seus respectivos elementos, no formato `{ "listaPaginada": [ "string" ] }`;
- `POST /api/v1/busca-contato-lista`: recebe um indicador de quantos contatos devem ser incluídos, um termo de pesquisa e uma lista de contatos no formato `{ "quantidadeRegistro": 0, "busca": "string", "listaContatos": [ { "nome": "string", "telefone": "string" } ] }` e devolve uma lista dos contatos incluídos cujo nome contenham o termo buscado, no formato `{ "listaContatos": [ { "nome": "string", "telefone": "string" } ] }`;
- `POST /api/v1/quantidade-palavras`: recebe um texto e uma palavra a ser contada no texto recebido, no formato `{ "texto": "string", "palavra": "string" }`, e devolve o número de ocorrências da palavra no texto,no formato `{ "quantidadeOcorrencias": 0 }`;
- `POST /api/v1/tem-vencedor`: recebe os valores de um jogo-da-velha no formato `{ "jogo": [ [ "o", "x", " " ], [ " ", "o", "x" ], [ " ", "o", "x" ] ] }` e devolve se o jogo tem vencedor ou não,no formato `{ "temVencedor": true }`.

O canal indicado para dúvidas é criar uma [`issue`](https://github.com/7comminformatica/recrutamento-dotnet-2c2c1/issues) e entrar em contato com a empresa para informar sobre as dúvidas, afim de manter uma base de conhecimento centralizada neste repositório, onde dúvidas anteriores poderão ser pesquisadas e agilizar a resposta ao entrar em contato com a empresa.
