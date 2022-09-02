using Microsoft.AspNetCore.Mvc;
using src.Models;

using Microsoft.EntityFrameworkCore;
using src.Persistence;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController: ControllerBase{

    private DatabaseContext _context {get; set;}

    private PersonController(DatabaseContext context)
    {
        this._context = context;
    }

    [HttpGet]

    public List<Pessoa> Get(){
        //Pessoa pessoa = new Pessoa("luciana", 19,"12345678");
        //Contrato novoContrato = new Contrato("abc123", 50.46);

       // pessoa.contratos.Add(novoContrato);  

        return _context.Pessoas.Include(p => p.contratos)Tolist();
    }
    
    [HttpPost]
    public Pessoa Post([FromBody]Pessoa pessoa){
        
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();

        return pessoa;
    }

    [HttpPut("{id}")]

    public string Update([FromRoute]int id,[FromBody]Pessoa pessoa){
        Console.WriteLine(id);
        Console.WriteLine(pessoa);
        return "Dados do id " + id + " atualizados";
    }

    [HttpDelete("{id}")]  
    public string Delete([FromRoute]int id){
        return "deletado pessoa de id " + id;
    }

}
