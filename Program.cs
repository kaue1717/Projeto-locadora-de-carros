using System;

class Carro
{
    public string Modelo { get; set; }
    public string Cor { get; set; }
    public string Marca { get; set; }
    public string Placa { get; set; }
    public bool Disponivel { get; private set; }

    public Carro(string modelo, string cor, string marca, string placa)
    {
        Modelo = modelo;
        Cor = cor;
        Marca = marca;
        Placa = placa;
        Disponivel = true;
    }

    public void Alugar()
    {
        Disponivel = false;
        Console.WriteLine($"🚗 O carro {Modelo} foi alugado.");
    }

    public void Devolver()
    {
        Disponivel = true;
        Console.WriteLine($"✅ O carro {Modelo} foi devolvido.");
    }
}

// Classe Cliente separada
class Cliente
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Telefone { get; set; }

    public Cliente(string nome, string cpf, string telefone)
    {
        Nome = nome;
        CPF = cpf;
        Telefone = telefone;
    }
}

// Classe Locacao separada
class Locacao
{
    public Cliente Cliente { get; set; }
    public Carro Carro { get; set; }
    public DateTime DataLocacao { get; set; }
    public DateTime DataInicio { get; }
    public DateTime DataFim { get; set; }

    public Locacao(Cliente cliente, Carro carro, DateTime dataInicio)
    {
        Cliente = cliente;
        Carro = carro;
        DataInicio = dataInicio;
        DataLocacao = DateTime.Now; // Assumindo que a locação ocorre no momento de criação
        Carro.Alugar();
    }

    public void FinalizarLocacao(DateTime dataFim)
    {
        DataFim = dataFim;
        Carro.Devolver();
        Console.WriteLine($"📅 Locação encerrada. Cliente: {Cliente.Nome}, Carro: {Carro.Modelo}, Período: {DataInicio} a {DataFim}");
    }
}

class Program
{
    static void Main()
    {
        Carro carro1 = new Carro("Camaro", "Amarelo", "Chevrolet", "ABC-1234");
    Cliente cliente1 = new Cliente("Bruno Rodrigues", "123.456.789-00", "(11) 98765-4321");
        Locacao locacao1 = new Locacao(cliente1, carro1, DateTime.Now);

        // Simulando o final da locação após 3 dias
        locacao1.FinalizarLocacao(DateTime.Now.AddDays(3));
    }
}
