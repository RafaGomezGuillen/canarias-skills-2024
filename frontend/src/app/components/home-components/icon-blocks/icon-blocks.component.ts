import { Component } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-icon-blocks',
  templateUrl: './icon-blocks.component.html',
  styles: ``,
})
export class IconBlocksComponent {
  items = [
    {
      svg: this.sanitizer.bypassSecurityTrustHtml(` <svg
      class="flex-shrink-0 w-9 h-9 text-default"
      xmlns="http://www.w3.org/2000/svg"
      width="24"
      height="24"
      viewBox="0 0 24 24"
      fill="none"
      stroke="currentColor"
      stroke-width="2"
      stroke-linecap="round"
      stroke-linejoin="round"
    >
      <rect width="10" height="14" x="3" y="8" rx="2" />
      <path d="M5 4a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v16a2 2 0 0 1-2 2h-2.4" />
      <path d="M8 18h.01" />
    </svg>`),
      title: '1.- Responsive',
      description: ' Responsive, and mobile-first project on the web',
    },
    {
      svg: this.sanitizer.bypassSecurityTrustHtml(` <svg
      class="flex-shrink-0 w-9 h-9 text-default"
      xmlns="http://www.w3.org/2000/svg"
      width="24"
      height="24"
      viewBox="0 0 24 24"
      fill="none"
      stroke="currentColor"
      stroke-width="2"
      stroke-linecap="round"
      stroke-linejoin="round"
    >
      <path d="M20 7h-9" />
      <path d="M14 17H5" />
      <circle cx="17" cy="17" r="3" />
      <circle cx="7" cy="7" r="3" />
    </svg>`),
      title: '2.- Customizable',
      description: 'Components are easily customized and extendable',
    },
    {
      svg: this.sanitizer.bypassSecurityTrustHtml(` <svg
      class="flex-shrink-0 w-9 h-9 text-default"
      xmlns="http://www.w3.org/2000/svg"
      width="24"
      height="24"
      viewBox="0 0 24 24"
      fill="none"
      stroke="currentColor"
      stroke-width="2"
      stroke-linecap="round"
      stroke-linejoin="round"
    >
      <path d="M2 3h6a4 4 0 0 1 4 4v14a3 3 0 0 0-3-3H2z" />
      <path d="M22 3h-6a4 4 0 0 0-4 4v14a3 3 0 0 1 3-3h7z" />
    </svg>`),
      title: '3.- Documentation',
      description: 'Every component and plugin is well documented',
    },
    {
      svg: this.sanitizer.bypassSecurityTrustHtml(`<svg
      class="flex-shrink-0 w-9 h-9 text-default"
      xmlns="http://www.w3.org/2000/svg"
      width="24"
      height="24"
      viewBox="0 0 24 24"
      fill="none"
      stroke="currentColor"
      stroke-width="2"
      stroke-linecap="round"
      stroke-linejoin="round"
    >
      <path
        d="M14 9a2 2 0 0 1-2 2H6l-4 4V4c0-1.1.9-2 2-2h8a2 2 0 0 1 2 2v5Z"
      />
      <path d="M18 9h2a2 2 0 0 1 2 2v11l-4-4h-6a2 2 0 0 1-2-2v-1" />
    </svg>`),
      title: '4.- 24/7 Support',
      description: 'Contact us 24 hours a day, 7 days a week',
    },
  ];
  
  constructor(private sanitizer: DomSanitizer) {}
}
