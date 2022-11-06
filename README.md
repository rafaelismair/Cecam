Conforme conversamos, seguem instruções referentes ao teste prático envolvendo algumas das tecnologias de nossos projetos.
Com base em sua interpretação, você tem toda liberdade para complementar com os recursos e técnicas que julgar necessário para executar o teste.

Os requisitos técnicos são:
.Net FullFramework
Asp.Net (WebForms)
Divisão mínima de camadas: 
entidades
repositório de acesso a dados
camada de apresentação
Para acesso a dados, podem ser usadas essas opções:
Entity Framework 
Dapper
ADO
Requisitos de negócio:
Deverá ser criado um sistema para gestão de clientes.
Deverão existir apenas duas páginas:
uma para cadastrar os clientes;
outra para listar os clientes cadastrados.
Os dados a serem cadastrados são:
Razão social
Nome fantasia
Contatos (telefone, e-mail etc.)
CNPJ
Identificação de quando o cliente é indicação de outro (deve haver referência de quem indicou)
A página de listagem deve exibir:
Razão social
Contatos
CNPJ
Nome do cliente que o indicou (caso haja)
Filtro por nome ou CNPJ