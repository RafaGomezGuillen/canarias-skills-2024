import { Component } from '@angular/core';
import { SalaService } from '../../../services/sala.service';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styles: ``
})
export class CardsComponent {
  constructor(public salaService: SalaService) {}

  ngOnInit(): void {
    this.salaService.get();
  }
}
