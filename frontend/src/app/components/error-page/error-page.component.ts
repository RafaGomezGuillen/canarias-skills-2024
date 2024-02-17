import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-error-page',
  templateUrl: './error-page.component.html',
})
export class ErrorPageComponent {
  @Input() errorType: string = '404 Error';
  @Input() errorTypeDescription: string = 'Page not found';

  goBack() {
    window.history.back();
  }
}
