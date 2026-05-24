import { Component, inject } from '@angular/core';
import { NavbarComponent } from '../../components/navbar/navbar';
import { ProductsService } from '../../services/products.service';
import { Product } from '../../models/product';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [NavbarComponent],
  templateUrl: './products.html',
  styleUrl: './products.css',
})
export class ProductsComponent {
  private svc = inject(ProductsService);

  products: Product[] = this.svc.getAll();
  categories: string[] = ['Todos', ...this.svc.getCategories()];
  selectedCategory = 'Todos';
  searchTerm = '';
  addedToCart = new Set<number>();
  brokenImages = new Set<number>();

  get filtered(): Product[] {
    let list = this.products;
    if (this.selectedCategory !== 'Todos') {
      list = list.filter((p) => p.category === this.selectedCategory);
    }
    const term = this.searchTerm.trim().toLowerCase();
    if (term) {
      list = list.filter(
        (p) => p.name.toLowerCase().includes(term) || p.description.toLowerCase().includes(term),
      );
    }
    return list;
  }

  selectCategory(cat: string) {
    this.selectedCategory = cat;
  }

  onSearch(event: Event) {
    this.searchTerm = (event.target as HTMLInputElement).value;
  }

  onImgError(id: number) {
    this.brokenImages.add(id);
  }

  addToCart(id: number) {
    this.addedToCart.add(id);
    setTimeout(() => this.addedToCart.delete(id), 2000);
  }

  formatQ(amount: number): string {
    return 'Q' + Math.round(amount).toLocaleString('es-GT');
  }

  discountedPrice(product: Product): string {
    return this.formatQ(product.price * (1 - (product.discount ?? 0) / 100));
  }
}
