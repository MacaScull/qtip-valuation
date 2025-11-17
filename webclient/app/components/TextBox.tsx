'use client'

import { useRef, useLayoutEffect } from "react"

interface TextBoxProps {
    inputValue: string,
    handleChange: (e: React.ChangeEvent<HTMLTextAreaElement>) => void
}

export default function TextBox({inputValue, handleChange}: TextBoxProps) {
    const textareaRef = useRef<HTMLTextAreaElement>(null)
    const overlayRef = useRef<HTMLDivElement>(null)

    useLayoutEffect(() => {
        const ta = textareaRef.current
        const ov = overlayRef.current 
        if (!ta || !ov) return

        const cs = getComputedStyle(ta)
        const props = [
            'fontFamily',
            'fontSize',
            'fontWeight',
            'fontStyle',
            'fontVariant',
            'letterSpacing',
            'textTransform',
            'textIndent',
            'lineHeight',
            'wordSpacing',
            'tabSize',
            'paddingTop',
            'paddingRight',
            'paddingBottom',
            'paddingLeft',
            'boxSizing',
        ]

        props.forEach((p: string) => {
            const cssName = p.replace(/[A-Z]/g, (m) => '-' + m.toLowerCase())
            const value = cs.getPropertyValue(cssName)
            if (value) ov.style.setProperty(cssName, value)
        })

        ov.style.width = `${ta.clientWidth}px`
        ov.style.height = `${ta.clientHeight}px`
    }, [inputValue])


    const highlightedHTML = inputValue.replace(
        /\b[\w-\.]+@([\w-]+\.)+[\w-]{2,}\b/g,
        (match) => `<span class="error-word tooltip" data-tip="PII – Email Address">${match}</span>`
    );

    return (
        <div className="relative w-full max-w-lg">
            
            <div
                ref={overlayRef}
                className="absolute inset-0 p-4 overlay overlay-text text-transparent"
                dangerouslySetInnerHTML={{ __html: highlightedHTML + "\n" }}
            />

            <textarea
                ref={textareaRef}
                className="textarea textarea-xl w-full p-4 relative bg-transparent"
                placeholder="Text input"
                value={inputValue}
                onChange={handleChange}
            />
        </div>
    )
}
