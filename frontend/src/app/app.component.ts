import { Component } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router, Event } from '@angular/router';
import { filter } from 'rxjs/operators';

// Preline UI
import { IStaticMethods } from 'preline/preline';
declare global {
  interface Window {
    HSStaticMethods: IStaticMethods;
  }
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: [],
})
export class AppComponent {
  isAuthPage: boolean = false;

  constructor(private router: Router, private activatedRoute: ActivatedRoute) {
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe(() => {
        this.isAuthPage =
          this.activatedRoute.firstChild?.snapshot.routeConfig?.path ===
            'login' ||
          this.activatedRoute.firstChild?.snapshot.routeConfig?.path ===
            'register' ||
          this.activatedRoute.firstChild?.snapshot.routeConfig?.path ===
            'not-found';
      });
  }

  // Preline UI
  ngOnInit() {
    this.router.events.subscribe((event: Event) => {
      if (event instanceof NavigationEnd) {
        setTimeout(() => {
          window.HSStaticMethods.autoInit();
        }, 100);
      }
    });
  }
}
