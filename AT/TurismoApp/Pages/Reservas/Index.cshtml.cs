public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Reserva> Reserva { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Reserva = await _context.Reservas
            .Where(r => r.Ativo)
            .ToListAsync();
    }
}
