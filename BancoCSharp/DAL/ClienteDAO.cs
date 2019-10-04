using BancoCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoCSharp.DAL
{
    class ClienteDAO
    { 
        private static Context ctx = new Context();

        public static Cliente BuscarClientePorCpf(Cliente c)
        {
            return ctx.Clientes.FirstOrDefault
                (x => x.Cpf.Equals(c.Cpf));
        }

        public static bool CadastrarCliente(Cliente c)
        {
            try
            {
                ctx.Usuarios.Attach(c.UsuarioId);
                ctx.Clientes.Add(c);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int BuscarClientePorUsuario(int id)
        {
            var cliente = ctx.Clientes.Where(x => x.UsuarioId.Id.Equals(id)).FirstOrDefault();

            return cliente.Id;
        }

        public static Cliente BuscarClientePorUsuarioId(int id)
        {
            Cliente cliente = ctx.Clientes.Where(x => x.UsuarioId.Id.Equals(id)).FirstOrDefault();

            return cliente;
        }



        public static Usuario RetornaLogin(string login)
        {
            var RetornaUsuario = ctx.Usuarios.SqlQuery("Select id from Usuario Where login = '" + login + "'").FirstOrDefault();
            return RetornaUsuario;

        }

        public static Cliente ConsultaClientePorLogin(string login)
        {
            var RetornaClienteId = ctx.Clientes.SqlQuery("select c.id from Cliente c inner join Usuario u on c.UsuarioId_id = u.id where u.login like '%" + login + "%'").FirstOrDefault();
            return RetornaClienteId;

        }

        public static Cliente BuscarClientePorId(int clienteId)
        {
            var cliente = ctx.Clientes.Where(x => x.Id.Equals(clienteId)).FirstOrDefault();
            return cliente;
        }





        /*                  TUDO DA CONTADAO PARA NAO DAR ERRO DE CONTEXT                   */


        public static Conta BuscarContaPorDigConta(Conta c)
        {
            return ctx.Contas.FirstOrDefault(x => x.DigConta.Equals(c.DigConta));
        }

        public static bool CadastrarConta(Conta c)
        {
            try
            {
                ctx.Clientes.Attach(c.ClienteId);
                ctx.Contas.Add(c);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static List<Conta> ListarContas(int clienteId)
        {
            return ctx.Contas.Where(x => x.ClienteId.Id.Equals(clienteId)).ToList();
        }

        public static bool RealizaSaque(Conta conta, int valorSaque)
        {
            var objConta = BuscarContaPorDigConta(conta);

            if (objConta != null)
            {
                if (objConta.Saldo >= valorSaque)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }


        public static int BuscarContaPorClienteId(int clienteId)
        {
            var conta = ctx.Contas.Where(x => x.ClienteId.Id.Equals(clienteId)).FirstOrDefault();

            return conta.Id;
        }

        //public static Cliente BuscarClientePorId(int clienteId)
        //{
        //    var cliente = ctx.Clientes.Where(x => x.Id.Equals(clienteId)).FirstOrDefault();

        //    return cliente;
        }
    }


