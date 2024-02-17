import { Component } from '@angular/core';

@Component({
  selector: 'app-careers',
  templateUrl: './careers.component.html',
  styles: ``,
})
export class CareersComponent {
  items = [
    {
      title: '45k+',
      description: ' users - from new startups to public companies',
    },
    {
      title: '23%',
      description: 'increase in traffic on webpages with Looms',
    },
    {
      title: '9.3%',
      description: 'boost in reply rates across sales outreach',
    },
    {
      title: '2x',
      description: 'faster than previous Preline versions',
    },
  ];

  positions = [
    {
      href: "#",
      title: 'Management',
      description: '4 job positions',
    },
    {
      href: "#",
      title: 'App Development',
      description: '26 job positions',
    },
    {
      href: "#",
      title: 'Arts & Entertainment',
      description: '9 job positions',
    },
    {
      href: "#",
      title: 'Accounting',
      description: '11 job positions',
    },
    {
      href: "#",
      title: 'UI Designer',
      description: '37 job positions',
    },
    {
      href: "#",
      title: 'Apps',
      description: '2 job positions',
    },
    {
      href: "#",
      title: 'Content Writer',
      description: '10 job positions',
    },
    {
      href: "#",
      title: 'Analytics',
      description: '14 job positions',
    },
  ];
}
