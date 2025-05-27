export class VacancyPage {
    /**
     * @param {import('@playwright/test').Page} page
     */
    constructor(page) {
      this.page = page;
      this.titleSelector = 'h1'; // adjust if needed
    }
  
    async getTitle() {
      await this.page.waitForSelector(this.titleSelector);
      return await this.page.textContent(this.titleSelector);
    }
  }
  