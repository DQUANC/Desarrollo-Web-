import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

export interface Address {
  street: string;
  suite: string;
  city: string;
  zipcode: string;
}

export interface Company {
  name: string;
  catchPhrase: string;
  bs: string;
}

export interface User {
  id: number;
  name: string;
  username: string;
  email: string;
  address: Address;
  phone: string;
  website: string;
  company: Company;
}

export interface Client {
  id: number;
  name: string;
  email: string;
  phone: string;
  company: string;
  initials: string;
}

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private readonly apiUrl = 'https://jsonplaceholder.typicode.com/users';

  constructor(private http: HttpClient) {}

  getClients(): Observable<Client[]> {
    return this.http.get<User[]>(this.apiUrl).pipe(
      map((users: User[]) =>
        users.map((user: User) => ({
          id: user.id,
          name: this.capitalizeName(user.name),
          email: user.email.toLowerCase(),
          phone: this.formatPhone(user.phone),
          company: user.company.name,
          initials: this.getInitials(user.name),
        }))
      )
    );
  }

  private capitalizeName(name: string): string {
    return name
      .split(' ')
      .map((word) => word.charAt(0).toUpperCase() + word.slice(1).toLowerCase())
      .join(' ');
  }

  private formatPhone(phone: string): string {
    return phone.split(' x')[0].trim();
  }

  private getInitials(name: string): string {
    return name
      .split(' ')
      .slice(0, 2)
      .map((word) => word.charAt(0).toUpperCase())
      .join('');
  }
}
