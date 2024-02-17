import { Component } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styles: ``,
})
export class AboutComponent {
  items = [
    {
      svg: this.sanitizer.bypassSecurityTrustHtml(`
        <svg
          class="flex-shrink-0 mt-1 w-6 h-6 text-primary"
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="2"
          stroke-linecap="round"
          stroke-linejoin="round"
        >
          <rect width="18" height="10" x="3" y="11" rx="2" />
          <circle cx="12" cy="5" r="2" />
          <path d="M12 7v4" />
          <line x1="8" x2="8" y1="16" y2="16" />
          <line x1="16" x2="16" y1="16" y2="16" />
        </svg>
      `),
      title: 'Creative minds',
      description:
        'We choose our teams carefully. Our people are the secret to great work.',
    },
    {
      svg: this.sanitizer.bypassSecurityTrustHtml(`
      <svg
      class="flex-shrink-0 mt-1 w-6 h-6 text-primary"
      xmlns="http://www.w3.org/2000/svg"
      viewBox="0 0 24 24"
      fill="none"
      stroke="currentColor"
      stroke-width="2"
      stroke-linecap="round"
      stroke-linejoin="round"
    >
      <path d="M7 10v12" />
      <path
        d="M15 5.88 14 10h5.83a2 2 0 0 1 1.92 2.56l-2.33 8A2 2 0 0 1 17.5 22H4a2 2 0 0 1-2-2v-8a2 2 0 0 1 2-2h2.76a2 2 0 0 0 1.79-1.11L12 2h0a3.13 3.13 0 0 1 3 3.88Z"
      />
      `),
      title: 'Simple and affordable',
      description:
        'From boarding passes to movie tickets, there is pretty much nothing you can not store with Preline.',
    },
    {
      svg: this.sanitizer.bypassSecurityTrustHtml(`
      <svg
      class="flex-shrink-0 mt-1 w-6 h-6 text-primary"
      xmlns="http://www.w3.org/2000/svg"
      viewBox="0 0 24 24"
      fill="none"
      stroke="currentColor"
      stroke-width="2"
      stroke-linecap="round"
      stroke-linejoin="round"
    >
      <path d="M2 3h6a4 4 0 0 1 4 4v14a3 3 0 0 0-3-3H2z" />
      <path d="M22 3h-6a4 4 0 0 0-4 4v14a3 3 0 0 1 3-3h7z" />
    </svg>
      `),
      title: 'Industry-leading documentation',
      description:
        'Our documentation and extensive Client libraries contain everything a business needs to build a custom integration.',
    },
    {
      svg: this.sanitizer.bypassSecurityTrustHtml(`
        <svg
          class="flex-shrink-0 mt-1 w-6 h-6 text-primary"
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="2"
          stroke-linecap="round"
          stroke-linejoin="round"
        >
          <path d="M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2" />
          <circle cx="9" cy="7" r="4" />
          <path d="M22 21v-2a4 4 0 0 0-3-3.87" />
          <path d="M16 3.13a4 4 0 0 1 0 7.75" />
        </svg>
      `),
      title: 'Designing for people',
      description:
        'We actively pursue the right balance between functionality and aesthetics, creating delightful experiences.',
    },
  ];

  titles = [
    'Easy & fastdesigning',
    'Powerful features',
    'User Experience Design',
  ];

  teams = [
    {
      img: 'https://images.unsplash.com/photo-1568602471122-7832951cc4c5?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=facearea&facepad=2&w=900&h=900&q=80',
      name: 'David Forren',
      position: 'Founder / CEO',
    },
    {
      img: 'https://images.unsplash.com/photo-1438761681033-6461ffad8d80?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=facearea&facepad=2&w=900&h=900&q=80',
      name: 'Amil Evara',
      position: 'UI/UX Designer',
    },
    {
      img: 'https://images.unsplash.com/photo-1548142813-c348350df52b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=facearea&facepad=2&w=900&h=900&q=80',
      name: 'Ebele Egbuna',
      position: 'Support Consultant',
    },
    {
      img: 'https://images.unsplash.com/photo-1492562080023-ab3db95bfbce?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=facearea&facepad=2&w=900&h=900&q=80',
      name: 'Maria Powers',
      position: 'Director of sales',
    },
    {
      img: 'https://images.unsplash.com/photo-1580489944761-15a19d654956?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=facearea&facepad=2&w=900&h=900&q=80',
      name: 'Delia Pawelke',
      position: 'Front-end Developer',
    },
    {
      img: 'https://images.unsplash.com/photo-1624224971170-2f84fed5eb5e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=facearea&facepad=2&w=900&h=900&q=80',
      name: 'Tom Lowry',
      position: 'UI/UX Designer',
    },
  ];

  constructor(private sanitizer: DomSanitizer) {}
}
