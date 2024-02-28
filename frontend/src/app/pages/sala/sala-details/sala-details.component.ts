import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { SalaService } from '../../../services/sala.service';

@Component({
  selector: 'app-sala-details',
  templateUrl: './sala-details.component.html',
  styles: ``
})
export class SalaDetailsComponent {
  constructor(
    private activatedRoute: ActivatedRoute,
    public salaService: SalaService,
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      const id = params['id'];
      this.salaService.getSala(id);
    });
  }
}
