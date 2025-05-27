export class SearchPage {
    /**
     * @param {import('@playwright/test').Page} page
     */
    constructor(page) {
      this.page = page;
      this.searchResultInput = 'input[name="search"]';
      this.resultSelector = '//div[@class="gsc-webResult gsc-result"]';
    }
  
    async getSearchValue() {
      await this.page.waitForSelector(this.searchResultInput);
      return await this.page.inputValue(this.searchResultInput);
    }
  
    async waitForResults() {
      await this.page.waitForSelector(this.resultSelector);
    }
  
    async getResultsCount() {
      const results = await this.page.$$(this.resultSelector);
      return results.length;
    }
  
    async clickFirstVacancy() {
        // Wait explicitly for at least one result to appear
        await this.page.waitForSelector(this.resultSelector);
      
        const results = await this.page.$$(this.resultSelector);
        if (results.length === 0) {
          throw new Error('No vacancy results found to click.');
        }
      
        (await results[0].$('//a[@class="gs-title"]')).click();
      }      
  }
  