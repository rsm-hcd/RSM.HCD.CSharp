// @ts-check
// Note: type annotations allow type checking and IDEs autocompletion

const lightCodeTheme = require("prism-react-renderer/themes/github");
const darkCodeTheme = require("prism-react-renderer/themes/dracula");

/** @type {import('@docusaurus/types').Config} */
const config = {
    title: "AndcultureCode.CSharp",
    tagline:
        "Commonly used interfaces, patterns and utilities by andculture engineering",
    url: "https://andculturecode.github.io",
    baseUrl: "/AndcultureCode.CSharp/",
    onBrokenLinks: "throw",
    onBrokenMarkdownLinks: "warn",
    favicon: "img/favicon.ico",
    organizationName: "AndcultureCode",
    projectName: "AndcultureCode.CSharp",

    // Even if you don't use internalization, you can use this field to set useful
    // metadata like html lang. For example, if your site is Chinese, you may want
    // to replace "en" with "zh-Hans".
    i18n: {
        defaultLocale: "en",
        locales: ["en"],
    },

    presets: [
        [
            "classic",
            /** @type {import('@docusaurus/preset-classic').Options} */
            ({
                docs: {
                    sidebarPath: require.resolve("./sidebars.js"),
                    // Please change this to your repo.
                    // Remove this to remove the "edit this page" links.
                    editUrl:
                        "https://github.com/facebook/docusaurus/tree/main/packages/create-docusaurus/templates/shared/",
                },
                blog: {
                    showReadingTime: true,
                    // Please change this to your repo.
                    editUrl:
                        "https://github.com/facebook/docusaurus/edit/master/website/blog/",
                },
                theme: {
                    customCss: require.resolve("./src/css/custom.css"),
                },
            }),
        ],
    ],

    themeConfig:
        /** @type {import('@docusaurus/preset-classic').ThemeConfig} */
        ({
            // Replace with your project's social card
            image: "img/docusaurus-social-card.jpg",
            navbar: {
                title: "AndcultureCode.CSharp",
                logo: {
                    alt: "AndcultureCode.CSharp",
                    src: "img/logo.jpg",
                },
                items: [
                    {
                        href: "https://github.com/AndcultureCode/AndcultureCode.CSharp",
                        label: "GitHub",
                        position: "right",
                    },
                ],
            },
            footer: {
                style: "dark",
                links: [
                    {
                        title: "Community",
                        items: [
                            {
                                label: "Github",
                                href: "https://github.com/AndcultureCode",
                            },
                        ],
                    },
                ],
                copyright: `Copyright © ${new Date().getFullYear()} andculture, Inc. Built with Docusaurus.`,
            },
            prism: {
                additionalLanguages: ["csharp"],
                theme: lightCodeTheme,
                darkTheme: darkCodeTheme,
            },
        }),
};

module.exports = config;
