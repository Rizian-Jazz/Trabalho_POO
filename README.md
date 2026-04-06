# Biblioteca de Ações em Unity
## Descrição
Este trabalho consiste na criação de uma biblioteca de classes em C# para Unity que permite adicionar ações a um GameObject, como pulo, pulo duplo, dash e andar em quadrado.
A biblioteca foi desenvolvida utilizando Programação Orientada a Objetos, com herança e classes abstratas para organizar as ações e os controladores de personagem.
## Classes do Projeto
### BaseCharacterController
Classe abstrata responsável por controlar o personagem e permitir a execução das ações.
### PlayerCharacterController
Herda de BaseCharacterController e executa as ações através do teclado usando o Input System.
### NonPlayerableController
Herda de BaseCharacterController e executa as ações automaticamente com um algoritmo randômico.
## Sistema de Ações
### ActionModel
Classe abstrata que define o padrão das ações e controla se elas podem ser executadas.
### JumpAction
Responsável pelo pulo simples.
### DoubleJumpAction
Responsável pelo pulo duplo e detecção do chão.
### DashAction
Responsável pelo dash do personagem.
### SquareWalkAction
Responsável por fazer o personagem andar em forma de quadrado.
## Observação
Toda a configuração do sistema foi feita de forma automática via código, evitando dependência do Inspector e permitindo fácil reutilização da biblioteca em diferentes projetos.

## Autor👽
Projeto desenvolvido como trabalho acadêmico para disciplina de programação com Unity.
