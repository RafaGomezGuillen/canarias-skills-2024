import { Component } from '@angular/core';
import { SalaService } from '../../../services/sala.service';

@Component({
  selector: 'app-sala-list',
  templateUrl: './sala-list.component.html',
  styles: ``,
})
export class SalaListComponent {
  constructor(public salaService: SalaService) {}

  ngOnInit(): void {
    this.salaService.get();
  }
}
