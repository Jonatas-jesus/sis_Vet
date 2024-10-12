using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Configuration;

namespace ca_sisVet_menuInterativo
{
    internal class Program
    {
        private static object configurationManeger;

        static void SalvarEspeciesEmCsv(List<Especies> banco, string caminho)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(caminho))
                {
                    writer.WriteLine("id, nome");

                    foreach (var item in banco)
                    {
                        writer.WriteLine(
                            $"{item.id},{item.nome}"); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }

        static List<Especies> CarregarEspeciesDoCsv(string caminho)
        {
            var especies = new List<Especies>();

            try
            {
                if (File.Exists(caminho) == true)
                {
                    using (StreamReader reader = new StreamReader(caminho))
                    {
                        string linha = reader.ReadLine();
                        while ((linha = reader.ReadLine()) != null)
                        {
                            var partes = linha.Split(',');
                            if (partes.Length == 3)
                            {
                                int id = int.Parse(partes[0]);
                                string nome = partes[1];
                                string espcancelada = partes[2];
                                especies.Add(new Especies
                                {
                                    id = id,
                                    nome = nome,
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message); throw;
            }
            return especies;
        }

        static void SalvarAnimalEmCsv(List<Animal> banco, string caminho)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(caminho))
                {
                    writer.WriteLine("id,nome,apelido,data_nascimento,observacoes");

                    foreach (var item in banco)
                    {
                        writer.WriteLine(
                            $"{item.id},{item.nome},{item.apelido},{item.data_nascimento},{item.observacoes}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }

        static List<Animal> CarregarAnimalDoCsv(string caminho)
        {
            var animal = new List<Animal>();

            try
            {
                if (File.Exists(caminho) == true)
                {
                    using (StreamReader reader = new StreamReader(caminho))
                    {
                        string linha = reader.ReadLine();
                        while ((linha = reader.ReadLine()) != null)
                        {
                            var partes = linha.Split(',');
                            if (partes.Length == 5)
                            {
                                int id = int.Parse(partes[0]);
                                string nome = partes[1];
                                string apelido = partes[2];
                                string data_nascimento = partes[3];
                                string observacoes = partes[4];
                                animal.Add(new Animal
                                {
                                    id = id,
                                    nome = nome,
                                    apelido = apelido,
                                    data_nascimento = data_nascimento,
                                    observacoes = observacoes
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message); throw;
            }
            return animal;
        }

        static void SalvarClienteEmCsv(List<Cliente> banco, string caminho)     
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(caminho))
                {
                    writer.WriteLine("id,nome,cpf,data_cadastro,email");

                    foreach (var item in banco)
                    {
                        writer.WriteLine(
                            $"{item.id},{item.nome},{item.cpf},{item.data_cadastro},{item.email}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }

        static List<Cliente> CarregarClienteDoCsv(string caminho)
        {
            var cliente = new List<Cliente>();

            try
            {
                if (File.Exists(caminho) == true)
                {
                    using (StreamReader reader = new StreamReader(caminho))
                    {
                        string linha = reader.ReadLine();
                        while ((linha = reader.ReadLine()) != null)
                        {
                            var partes = linha.Split(',');
                            if (partes.Length == 5)
                            {
                                int id = int.Parse(partes[0]);
                                string nome = partes[1];
                                string email = partes[2];
                                string data_cadastro = partes[3];
                                string cpf = partes[4];
                                cliente.Add(new Cliente
                                {
                                    id = id,
                                    nome = nome,
                                    email = email,
                                    data_cadastro = data_cadastro,
                                    cpf = cpf
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message); throw;
            }
            return cliente;
        }


        static void Main(string[] args)
        {
            //Variaveis
            int opcao = 0;
            int subopcao = 0;

            //Variáveis para armazenar dados da veterianaria em memória RAM
            List<Especies> BancoEspecies = new List<Especies>();
            Especies item;

            List<Animal> BancoAnimal = new List<Animal>();
            Animal itemAnimal;

            List<Cliente> BancoCliente = new List<Cliente>();
            Cliente itemCliente;

            string caminhoBanco = ConfigurationManager.AppSettings["caminhoBanco"];
            string nomeBancoEspecie = ConfigurationManager.AppSettings["nomeBancoEspecie"];
            string nomeBancoAnimal = ConfigurationManager.AppSettings["nomeBancoAnimal"];
            string nomeBancoCliente = ConfigurationManager.AppSettings["nomeBancoCliente"];

            BancoEspecies = CarregarEspeciesDoCsv(caminhoBanco + nomeBancoEspecie);
            BancoAnimal = CarregarAnimalDoCsv(caminhoBanco + nomeBancoAnimal);              
            BancoCliente = CarregarClienteDoCsv(caminhoBanco + nomeBancoCliente);

            string nome;
            string apelido;
            string email;
            string observacoes;
            string data_cadastro;
            string data_nascimento;
            int id;
            string cpf;

            while (opcao != 9)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Sistema Veterinária");
                Console.WriteLine("1. Especies");
                Console.WriteLine("2. Animal");
                Console.WriteLine("3. Cliente");
                Console.WriteLine("9. Sair");
                Console.WriteLine("Digite a opcao: ");
                opcao = int.Parse(Console.ReadLine());  // Faz leitura de entrada do usuário

                if (opcao == 1) //Especies
                {
                    subopcao = 0;

                    while (subopcao != 9)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("ESPECIES");
                        Console.WriteLine("1. Inserir");
                        Console.WriteLine("2. Alterar");
                        Console.WriteLine("3. Excluir");
                        Console.WriteLine("4. Pesquisar");
                        Console.WriteLine("5. Exibir");
                        Console.WriteLine("6. Salvar no banco de dados");
                        Console.WriteLine("9. Sair");
                        Console.WriteLine("Digite a opcao: ");
                        subopcao = int.Parse(Console.ReadLine());   //Faz a leitura e converte para número

                        switch (subopcao)
                        {
                            case 1:
                                Especies especies = new Especies(); //Criando o objeto

                                Console.WriteLine("Adicione o ID");
                                especies.id = int.Parse(Console.ReadLine());

                                Console.WriteLine("Nome da especie");
                                especies.nome = Console.ReadLine();  //Aqui escreve

                                BancoEspecies.Add(especies); // Adicionando á lista
                                break;

                            case 2:
                                Console.WriteLine("Insira a especie que deseja alterar:");
                                nome = Console.ReadLine();  

                                //Percorre a lista (Banco)
                                foreach(var item1 in BancoEspecies)
                                {
                                    if(item1.nome == nome.ToString().Trim())
                                    {
                                        Console.WriteLine("Especie localizada\nInforme a nova especie: ");
                                        item1.nome = Console.ReadLine();
                                        Console.WriteLine("Especie alterada com sucesso!");
                                        break;
                                    }
                                }
                                break;

                            case 3:
                                //Remove uma especie a partir de uma busca pelo nome
                                Console.WriteLine("Digite a especie que deseja excluir:");
                                nome = Console.ReadLine();  

                                //Percorre a lista (Banco)
                                foreach(var item2 in BancoEspecies)
                                {
                                    if(item2.nome == nome.ToString().Trim()) /*Perguntar ao chat o que esse comando faz*/
                                    {
                                        //Remove o item escolhido do banco Especies
                                        BancoEspecies.Remove(item2);
                                        Console.WriteLine("Item removido com sucesso");
                                        break;
                                    }
                                }
                                break;

                            case 4:
                                Console.WriteLine("Digite o nome da Especie que deseja pesquisar: ");
                                nome = Console.ReadLine();

                                foreach(var item3 in BancoEspecies)
                                {
                                    if(item3.nome == nome.ToString().Trim())
                                    {
                                        Console.WriteLine("Especie localizado");
                                        Console.WriteLine(item3.nome, item3.id);
                                        break;
                                    }
                                }
                                break;
                                
                            case 5:
                                Console.WriteLine("Especies Cadastradas");
                                if(BancoEspecies.Count == 0)
                                {
                                    Console.WriteLine("Nenhuma especies encontrada");
                                }
                                else
                                {
                                   
                                    foreach(var e in BancoEspecies)
                                    {
                                        Console.WriteLine($"ID: {e.id} / Especie:{e.nome}"); 
                                    }
                                }
                                break;

                             case 6:
                                Console.WriteLine("Salvo no Banco de dados");

                                SalvarEspeciesEmCsv(BancoEspecies, "especies.csv");
                                break;
                        }
                    }
                }

                if (opcao == 2) //Animal
                {
                    subopcao = 0;
                    while (subopcao != 9)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("..::ANIMAL::.."); 
                        Console.WriteLine("1. Inserir");
                        Console.WriteLine("2. Alterar");
                        Console.WriteLine("3. Excluir");
                        Console.WriteLine("4. Pesquisar");
                        Console.WriteLine("5. Exibir");
                        Console.WriteLine("6. Salvar no banco de dados");
                        Console.WriteLine("9. Sair");
                        Console.WriteLine("Digite a opcao: ");
                        subopcao = int.Parse(Console.ReadLine());

                        switch (subopcao)
                        {
                            case 1: //INSERIR 
                                Animal animal = new Animal();

                                Console.WriteLine("ID do animal: ");
                                animal.id = int.Parse(Console.ReadLine());

                                Console.WriteLine("Nome do animal:");
                                animal.nome = Console.ReadLine();

                                Console.WriteLine("Apelido do animal:");
                                animal.apelido = Console.ReadLine();

                                Console.WriteLine("Data de nascimento do animal (formato: dd/mm/aaaa):");
                                animal.data_nascimento = Console.ReadLine();

                                Console.WriteLine("Observações do animal:");
                                animal.observacoes = Console.ReadLine();

                                BancoAnimal.Add(animal);
                                Console.WriteLine("Animal adicionado com sucesso");
                                break;

                            case 2: //ALTERAR 
                                Console.WriteLine("...ALTERAR...\n\n");

                                Console.WriteLine("Digite o id do Animal que deseja alterar: ");
                                if (int.TryParse(Console.ReadLine(), out id))
                                {
                                    bool animalEncontrado = false;

                                    foreach (var item4 in BancoAnimal)
                                    {
                                        if (item4.id == id)
                                        {
                                            Console.WriteLine("ID localizada!");

                                            Console.WriteLine("Informe novo Nome (deixe em branco para manter o atual): ");
                                            string novoNome = Console.ReadLine();
                                            if (!string.IsNullOrWhiteSpace(novoNome))
                                            {
                                                item4.nome = novoNome;
                                            }

                                            Console.WriteLine("Informe novo Apelido (deixe em branco para manter o atual): ");
                                            string novoApelido = Console.ReadLine();
                                            if (!string.IsNullOrWhiteSpace(novoApelido))
                                            {
                                                item4.apelido = novoApelido;
                                            }

                                            Console.WriteLine("Informe nova Data de Nascimento do Animal (formato: dd/mm/aaaa) (deixe em branco para manter o atual):");
                                            string novoData_nascimento = Console.ReadLine();
                                            if (!string.IsNullOrWhiteSpace(novoData_nascimento))
                                            {
                                                item4.data_nascimento = novoData_nascimento;
                                            }

                                            Console.WriteLine("Informe novas Observações (deixe em branco para manter o atual): ");
                                            string novasObservacoes = Console.ReadLine();
                                            if (!string.IsNullOrWhiteSpace(novasObservacoes))
                                            {
                                                item4.observacoes = novasObservacoes;
                                            }

                                            Console.WriteLine("Alteração concluída!");
                                            animalEncontrado = true;
                                            break;
                                        }
                                    }

                                    if (!animalEncontrado)
                                    {
                                        Console.WriteLine("ID não localizado!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ID inválido! Por favor, insira um número.");
                                }
                                break;

                            case 3: //EXCLUIR 
                                Console.WriteLine("Digite o nome do animal");
                                nome = Console.ReadLine();
                                
                                foreach(var item5 in BancoAnimal)
                                {
                                    if(item5.nome == nome.ToString().Trim())
                                    {
                                        BancoAnimal.Remove(item5);
                                        Console.WriteLine("Animal removido com sucesso");
                                        break;
                                    }
                                }
                                break;

                            case 4: //PESQUISAR 
                                Console.WriteLine("Digite o id do animal que deseja pesquisar: ");
                                id = int.Parse(Console.ReadLine());

                                if (BancoAnimal.Count == 0)
                                {
                                    Console.WriteLine("Nenhum animal encontrado!");
                                }
                                else
                                {
                                    foreach (var e in BancoAnimal)
                                    {
                                        Console.WriteLine($"id:{e.id} / nome:{e.nome} / apelido:{e.apelido} / data nascimento:{e.data_nascimento} /observações:{e.observacoes}");
                                    }
                                }
                                break;

                            case 5://EXIBIR 
                                Console.WriteLine("Animais cadastrados:");
                                if (BancoAnimal.Count == 0)
                                {
                                    Console.WriteLine("Nenhum animal encontrado!");
                                }
                                else
                                {
                                    foreach (var e in BancoAnimal)
                                    {
                                        Console.WriteLine($"id:{e.id} / nome:{e.nome} / apelido:{e.apelido} / data nascimento:{e.data_nascimento} /observações:{e.observacoes}");
                                    }
                                }
                                break;

                                case 6:   //SALVAR NO BANCO
                                Console.WriteLine("Salvo no Banco de dados");

                                SalvarAnimalEmCsv(BancoAnimal, "animal.csv");
                                    break;
                        }
                    }
                }
                if (opcao == 3) //Cliente
                {
                    subopcao = 0;

                    while (subopcao != 9)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("CLIENTE");
                        Console.WriteLine("1. Inserir");
                        Console.WriteLine("2. Alterar");
                        Console.WriteLine("3. Excluir");
                        Console.WriteLine("4. Pesquisar");
                        Console.WriteLine("5. Exibir");
                        Console.WriteLine("6. Salvar no banco de dados");
                        Console.WriteLine("9. Sair");
                        Console.WriteLine("Digite a opcao: ");
                        subopcao = int.Parse(Console.ReadLine());   //Faz a leitura e converte para número

                        switch (subopcao)
                        {
                            case 1: //Inserir 
                                Cliente cliente = new Cliente();

                                Console.WriteLine("Id do Cliente");
                                cliente.id = int.Parse(Console.ReadLine());

                                Console.WriteLine("Nome do Cliente");
                                cliente.nome = Console.ReadLine();

                                Console.WriteLine("CPF do cliente");
                                cliente.cpf = Console.ReadLine();

                                Console.WriteLine("Email do cliente");
                                cliente.email = Console.ReadLine();

                                Console.WriteLine("Data de cadastro do cliente (Formato: dd/mm/aaaa)");
                                cliente.data_cadastro = Console.ReadLine();

                                BancoCliente.Add(cliente);
                                Console.WriteLine("Cliente adicionado com sucesso!");
                                break;

                            case 2: //Alterar 
                                Console.WriteLine("Digite o id do Cliente que deseja alterar: ");
                                if (int.TryParse(Console.ReadLine(), out id))
                                {
                                    bool clienteEncontrado = false;

                                    foreach (var item6 in BancoCliente)
                                    {
                                        if (item6.id == id)
                                        {
                                            Console.WriteLine("ID localizado!");

                                            Console.WriteLine("Informe novo Nome (deixe em branco para manter o atual): ");
                                            string novoNome = Console.ReadLine();
                                            if (!string.IsNullOrWhiteSpace(novoNome))
                                            {
                                                item6.nome = novoNome;
                                            }

                                            Console.WriteLine("Informe o novo Cpf (deixe em branco para manter o atual): ");
                                            string novoCpf = Console.ReadLine();
                                            if (!string.IsNullOrWhiteSpace(novoCpf))
                                            {
                                                item6.cpf = novoCpf;
                                            }

                                            Console.WriteLine("Informe o novo Email (deixe em branco para manter o atual): ");
                                            string novoEmail = Console.ReadLine();
                                            if (!string.IsNullOrWhiteSpace(novoEmail))
                                            {
                                                item6.email = novoEmail;
                                            }

                                            Console.WriteLine("Informe a nova Data de Cadastro (formato: dd/mm/aaaa) (deixe em branco para manter o atual):");
                                            string novoData_cadastro = Console.ReadLine();
                                            if (!string.IsNullOrWhiteSpace(novoData_cadastro))
                                            {
                                                item6.data_cadastro = novoData_cadastro;

                                                Console.WriteLine("Alteração concluída!");
                                                clienteEncontrado = true;
                                                break;
                                            }
                                        }

                                        if (!clienteEncontrado)
                                        {
                                            Console.WriteLine("ID não localizado!");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ID inválido! Por favor, insira um número.");
                                }
                                break;

                            case 3: //Excluir 
                                Console.WriteLine("Digite o nome do cliente que deseja exluir");
                                nome = Console.ReadLine();

                                foreach(var item7 in BancoCliente)
                                {
                                    if(item7.nome == nome.ToString().Trim())
                                    {
                                        BancoCliente.Remove(item7);
                                        Console.WriteLine("Cliente removido com sucesso!");
                                        break;
                                    }
                                }
                                break;

                            case 4: //Pesquisar 
                                Console.WriteLine("Digite o id do cliente que deseja pesquisar: ");
                                id = int.Parse(Console.ReadLine());

                                if (BancoCliente.Count == 0)
                                {
                                    Console.WriteLine("Nenhum animal encontrado!");
                                }
                                else
                                {
                                    foreach (var e in BancoCliente)
                                    {
                                        Console.WriteLine($"id:{e.id} / nome:{e.nome} / cpf:{e.cpf} / email:{e.email} / data cadastro:{e.data_cadastro}");
                                    }
                                }
                                break;

                            case 5: //Exibir //Salvar no banco
                                Console.WriteLine("Clientes cadastrados:");
                                if (BancoCliente.Count == 0)
                                {
                                    Console.WriteLine("Nenhum cliente encontrado!");
                                }
                                else
                                {
                                    foreach (var e in BancoCliente)
                                    {
                                        Console.WriteLine($"id:{e.id} / nome:{e.nome} / cpf:{e.cpf} / email:{e.email} / data cadastro{e.data_cadastro}");
                                    }
                                }
                                break;

                            case 6:
                                Console.WriteLine("Salvo no Banco de dados");

                                SalvarClienteEmCsv(BancoCliente, "cliente.csv");
                                break;
                        }
                    }
                }

            }
            SalvarEspeciesEmCsv(BancoEspecies, caminhoBanco + nomeBancoEspecie);
            SalvarAnimalEmCsv(BancoAnimal, caminhoBanco + nomeBancoAnimal);       
            SalvarClienteEmCsv(BancoCliente, caminhoBanco + nomeBancoCliente);        
        }
    }
}
