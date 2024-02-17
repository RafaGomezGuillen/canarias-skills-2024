import { Component } from '@angular/core';

@Component({
  selector: 'app-newsroom',
  templateUrl: './newsroom.component.html',
  styles: ``,
})
export class NewsroomComponent {
  news = [
    {
      href: '#',
      img: 'https://images.unsplash.com/photo-1668869713519-9bcbb0da7171?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=988&q=80',
      title: 'Better is when everything works together',
      description: 'Product',
    },
    {
      href: '#',
      img: 'https://images.unsplash.com/photo-1668584054035-f5ba7d426401?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=3465&q=80',
      title: 'What CFR really is about',
      description: 'Business',
    },
    {
      href: '#',
      img: 'https://images.unsplash.com/photo-1668863699009-1e3b4118675d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=3387&q=80',
      title: 'Should Product Owners think like entrepreneurs?',
      description: 'Business',
    },
    {
      href: '#',
      img: 'https://images.unsplash.com/photo-1668584054131-d5721c515211?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1064&q=80',
      title: 'Announcing Front Strategies: Ready-to-use rules',
      description: 'Facilitate',
    },
  ];
}
