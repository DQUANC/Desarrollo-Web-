import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { NavbarComponent } from '../../components/navbar/navbar';
import { ProductsService } from '../../services/products.service';
import { Product } from '../../models/product';

@Component({
  selector: 'app-offers',
  standalone: true,
  imports: [NavbarComponent, RouterLink],
  templateUrl: './offers.html',
  styleUrl: './offers.css',
})
export class OffersComponent {
  private svc = inject(ProductsService);

  offers: Product[] = this.svc.getOffers();
  addedToCart = new Set<number>();
  brokenImages = new Set<number>();

  formatQ(amount: number): string {
    return 'Q' + Math.round(amount).toLocaleString('es-GT');
  }

  discountedPrice(product: Product): string {
    return this.formatQ(product.price * (1 - (product.discount ?? 0) / 100));
  }

  savings(product: Product): string {
    return this.formatQ(product.price * ((product.discount ?? 0) / 100));
  }

  onImgError(id: number) {
    this.brokenImages.add(id);
  }

  addToCart(id: number) {
    this.addedToCart.add(id);
    setTimeout(() => this.addedToCart.delete(id), 2000);
  }
}
