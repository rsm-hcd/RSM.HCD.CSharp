/** @type {import('@docusaurus/types').DocusaurusConfig} */
module.exports = {
    title: "AndcultureCode.CSharp.Core",
    tagline:
        "Commonly used interfaces, patterns and utilities by andculture engineering",
    url: "https://andculturecode.github.io",
    baseUrl: "/AndcultureCode.CSharp.Core/",
    onBrokenLinks: "throw",
    onBrokenMarkdownLinks: "warn",
    favicon: "img/favicon.ico",
    organizationName: "AndcultureCode",
    projectName: "AndcultureCode.CSharp.Core",
    themeConfig: {
        prism: {
            additionalLanguages: ["csharp"],
        },
        navbar: {
            title: "AndcultureCode.CSharp.Core",
            logo: {
                alt: "AndcultureCode.CSharp.Core",
                src: "img/logo.jpg",
            },
            items: [
                {
                    href:
                        "https://github.com/AndcultureCode/AndcultureCode.CSharp.Core",
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
    },
    presets: [
        [
            "@docusaurus/preset-classic",
            {
                docs: {
                    sidebarPath: require.resolve("./sidebars.ts"),
                    // Please change this to your repo.
                    editUrl:
                        "https://github.com/facebook/docusaurus/edit/master/website/",
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
            },
        ],
    ],
};
