import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { UsersService, Client } from '../services/users';

@Component({
  selector: 'app-clients',
  standalone: false,
  templateUrl: './clients.html',
  styleUrl: './clients.scss',
})
export class Clients implements OnInit {
  clients: Client[] = [];
  isLoading = true;
  hasError = false;
  errorMessage = '';
  searchTerm = '';

  constructor(private usersService: UsersService, private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.loadClients();
  }

  loadClients(): void {
    this.isLoading = true;
    this.hasError = false;
    this.usersService.getClients().subscribe({
      next: (data: Client[]) => {
        this.clients = data;
        this.isLoading = false;
        this.cdr.detectChanges();
      },
      error: (err: Error) => {
        this.hasError = true;
        this.errorMessage = 'No se pudo cargar la lista de clientes. Verifique su conexion.';
        this.isLoading = false;
        this.cdr.detectChanges();
        console.error('Error loading clients:', err);
      },
    });
  }

  get filteredClients(): Client[] {
    if (!this.searchTerm.trim()) {
      return this.clients;
    }
    const term = this.searchTerm.toLowerCase();
    return this.clients.filter(
      (c) =>
        c.name.toLowerCase().includes(term) ||
        c.email.toLowerCase().includes(term) ||
        c.company.toLowerCase().includes(term)
    );
  }

  onSearch(event: Event): void {
    this.searchTerm = (event.target as HTMLInputElement).value;
  }
}
